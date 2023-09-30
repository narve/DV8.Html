using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV8.Html.Elements;
using DV8.Html.Support;
using static DV8.Html.Utils.Reflect;

namespace DV8.Html.Serialization;

public class HtmlSerializerRegistry : IHtmlSerializer
{
    public readonly List<IHtmlSerializer> Serializers = new List<IHtmlSerializer>();

    public bool CanSerialize(object o) => 
        Serializers.Any(ser => ser.CanSerialize(o));

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

    public IHtmlSerializer FindSerializer(object o) => Serializers.FirstOrDefault(ser => ser.CanSerialize(o));


    public HtmlSerializerRegistry Add(IHtmlSerializer ser)
    {
        Serializers.Add(ser);
        return this;
    }

    public HtmlSerializerRegistry Add(Func<object, bool> predicate,
        Func<object, int, IHtmlSerializer, IEnumerable<IHtmlElement>> serializer) =>
        Add(new FuncHtmlSerializer(predicate, serializer));

    public HtmlSerializerRegistry Add(Func<object, bool> predicate, Func<object, IEnumerable<IHtmlElement>> serializer) => Add(new FuncHtmlSerializer(predicate, serializer));

    public static HtmlSerializerRegistry GetDefault() => AddDefaults(new HtmlSerializerRegistry());
        
    public static HtmlSerializerRegistry AddDefaults(HtmlSerializerRegistry ser)
    {
        if (!HtmlSupport.Lasts.Contains("Links"))
        {
            HtmlSupport.Lasts.Add("Links");
        }

        if (!HtmlSupport.Firsts.Contains("Id"))
        {
            HtmlSupport.Firsts.Add("Id");
        }

        ser.Add(o => o == null, _ => Array.Empty<IHtmlElement>());
        ser.Add(o => o is IHtmlElement, o => ((IHtmlElement)o).ToArray());
        ser.Add(o => !IsNonPrimitive(o), o => new Span(o.ToString()).ToArray());
        ser.Add(o => o is IEnumerable, o => new ListSerializer().Serialize(o, 3, ser));
        ser.Add(IsNonPrimitive, o => new PropsSerializer{IncludeType = true}.Serialize(o, 3, ser));
        return ser;
    }
}