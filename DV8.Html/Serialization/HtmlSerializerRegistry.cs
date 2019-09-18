using System;
using System.Collections.Generic;
using System.Linq;
using DV8.Html.Elements;

namespace DV8.Html.Serialization
{
    public class HtmlSerializerRegistry : IHtmlSerializer
    {
        public List<IHtmlSerializer> Serializers = new List<IHtmlSerializer>();

        public bool CanSerialize(object o)
        {
            return Serializers.Any(ser => ser.CanSerialize(o));
        }

        public IEnumerable<IHtmlElement> Serialize(object o, int lvl, IHtmlSerializer fac = null)
        {
            if( lvl < 0 )
                return new IHtmlElement[0];
            var s = FindSerializer(o);
            if (s == null)
            {
                throw new ArgumentException($"Don't know how to serialize {o.GetType().FullName}");
            }
            return s.Serialize(o, lvl, fac??this);

        }

        public IHtmlSerializer FindSerializer(object o)
        {
            return Serializers.FirstOrDefault(ser => ser.CanSerialize(o));
        }


        public HtmlSerializerRegistry Add(IHtmlSerializer ser)
        {
            Serializers.Add(ser);
            return this;
        }

        public HtmlSerializerRegistry Add(Func<object, bool> predicate,
            Func<object, int, IHtmlSerializer, IEnumerable<IHtmlElement>> serializer)
        {
            return Add(new FuncHtmlSerializer(predicate, serializer));
        }

        public HtmlSerializerRegistry Add(Func<object, bool> predicate, Func<object, IEnumerable<IHtmlElement>> serializer)
        {
            return Add(new FuncHtmlSerializer(predicate, serializer));
        }
    }
}