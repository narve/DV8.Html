using System.Collections.Generic;
using System.Linq;
using DV8.Html.Elements;
using DV8.Html.Framework;
using DV8.Html.Support;
using DV8.Html.Utils;
using static DV8.Html.Prefixes.Underscore;

namespace DV8.Html.Serialization;

public class GenDictSerializer : IHtmlSerializer
{
    public bool CanSerialize(object o)
    {
        return o is IDictionary<string, object>;
    }

    public IEnumerable<IHtmlElement> Serialize(object x, int lvl, IHtmlSerializer fac)
    {
        var d = (IDictionary<string, object>) x;
        var itemtype = HtmlSupport.Itemtype(x);
        var subs = d.Keys.ToRawList().Cast<string>()
            .Select(name => new {Name = name, Val = d[name]})
//                    .Where(a => a.Val != null)
            .SelectMany(a => new IHtmlElement[]
            {
                _<Dt>(a.Name),
                new Dd
                {
                    Itemprop = a.Name,
                    Children = fac.Serialize(a.Val, lvl - 1, fac).ToList()
                }
            })
            .ToList();
        return new Ul
        {
            Children = subs,
            Itemscope = true,
            Itemtype = itemtype,
        }.ToArray();
    }
}