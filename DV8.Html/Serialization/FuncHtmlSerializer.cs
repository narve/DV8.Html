using System;
using System.Collections.Generic;
using DV8.Html.Elements;

namespace DV8.Html.Serialization
{
    public class FuncHtmlSerializer : IHtmlSerializer
    {
        public readonly Func<object, bool> Predicate;
        public readonly Func<object, int, IHtmlSerializer, IEnumerable<IHtmlElement>> Serializer;

        public FuncHtmlSerializer(Func<object, bool> predicate, Func<object, int, IHtmlSerializer, IEnumerable<IHtmlElement>> serializer)
        {
            Predicate = predicate;
            Serializer = serializer;
        }

        public FuncHtmlSerializer(Func<object, bool> predicate, Func<object, IEnumerable<IHtmlElement>> serializer)
        {
            Predicate = predicate;
            Serializer = (o, i, f) => serializer.Invoke(o);
        }


        public bool CanSerialize(object o)
        {
            return Predicate.Invoke(o);
        }

        public IEnumerable<IHtmlElement> Serialize(object o, int lvl, IHtmlSerializer fac)
        {
            return Serializer.Invoke(o, lvl, fac);
        }
    }
}