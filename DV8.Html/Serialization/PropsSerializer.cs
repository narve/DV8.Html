using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DV8.Html.Elements;
using DV8.Html.Framework;
using DV8.Html.Mutators;
using DV8.Html.Support;
using DV8.Html.Utils;

namespace DV8.Html.Serialization;

public class PropsSerializer : IHtmlSerializer
{
    public bool IncludeType { get; set; }

    public bool CanSerialize(object x) => true;

    public IEnumerable<IHtmlElement> Serialize(object x, int lvl, IHtmlSerializer fac) =>
        SerializeProps(x, lvl, fac, HtmlSupport.PropsOf(x.GetType()), IncludeType);

    public static string PropName(string pn) =>
        pn.LowercaseFirst();

    public static IEnumerable<IHtmlElement> SerializeProps(object x, int lvl, IHtmlSerializer fac, IEnumerable<MemberInfo> props, bool includeType)
    {
        var itemType = HtmlSupport.Itemtype(x);

        var subs = new List<IHtmlElement>();

        if (includeType)
        {
            subs.AddRange(new IHtmlElement[]
            {
                new Dt("Type"),
                new Dd(x.GetType().Name).WithTitle(itemType)
            });
        }

        props
            .Select(mi => new {mi.Name, Val = HtmlSupport.TryGetVal(mi, x)})
            .Where(a => a.Val != null)
            .SelectMany(a => new IHtmlElement[]
            {
                new Dt(a.Name),
                new Dd {Itemprop = PropName(a.Name), Children = fac.Serialize(a.Val, lvl - 1, fac).ToList()}
            })
            .ToList().ForEach(e => subs.Add(e));

        return new Dl
        {
            Children = subs.ToList(),
            Itemscope = true,
            Itemtype = itemType,
        }.ToArray();
    }
}