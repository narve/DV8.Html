using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV8.Html.Elements;
using DV8.Html.Support;
using DV8.Html.Utils;

namespace DV8.Html.Serialization;

public class ListSerializer : IHtmlSerializer
{
    public bool CanSerialize(object x)
    {
        return x is IEnumerable<object>;
    }

//            public static Type GetElementType( object o)
//            {
//                return o.GetType().GetGenericArguments().Length == 1
//                    ? o.GetType().GetGenericArguments()[0]
//                    : o.GetType().GetElementType();
//            }

    private static Type GetItemType(object someCollection)
    {
        var type = someCollection.GetType();
        var ienum = type.GetInterface(typeof(IEnumerable<>).Name);
        return ienum?.GetGenericArguments()[0];
    }

    public IEnumerable<IHtmlElement> Serialize(object o, int lvl, IHtmlSerializer fac)
    {
        //                Type elementType = GetElementType(o);
        //                Type elementType = GetItemType(o);
        if (o is IEnumerable)
            o = (o as IEnumerable).ToRawList();
        var elementType = o.GetType().GetGenericArguments().Length == 1
            ? o.GetType().GetGenericArguments()[0]
            : o.GetType().GetElementType();

        if (elementType == null)
            throw new ArgumentException($"Unable to find elementtype for {o.GetType()}");

        var itemType = HtmlSupport.GetItemType(elementType);
        return new Ul
        {
            Clz = "result-list " + itemType,
            Itemscope = true,
            Itemtype = HtmlSupport.Itemtype(o),
            Subs = ((IEnumerable<object>) o)
                .SelectMany(item => fac.Serialize(item, lvl - 1, fac))
                .Select(elem => new Li(elem))
                .OfType<IHtmlElement>()
                .ToList(),
        }.ToArray();
    }
}