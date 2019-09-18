using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DV8.Html.Elements;
using DV8.Html.Support;
using DV8.Html.Utils;

namespace DV8.Html.Serialization
{

        public class PropsSerializer : IHtmlSerializer
        {
            public bool CanSerialize(object x)
            {
                return true;
            }

            public IEnumerable<IHtmlElement> Serialize(object x, int lvl, IHtmlSerializer fac)
            {
                return SerializeProps(x, lvl, fac, HtmlSupport.PropsOf(x.GetType()));
            }

            public static string PropName(string pn)
            {
                return pn.LowercaseFirst();
            }

            public static IEnumerable<IHtmlElement> SerializeProps(object x, int lvl, IHtmlSerializer fac, List<MemberInfo> props)
            {
                string itemtype = HtmlSupport.Itemtype(x);
                var subs = props
                    .Select(mi => new {mi.Name, Val = HtmlSupport.TryGetVal(mi, x)})
                    .Where(a => a.Val != null)
                    .SelectMany(a => new IHtmlElement[]
                    {
                        new Dt(a.Name),
                        new Dd {Itemprop = PropName(a.Name), Subs = fac.Serialize(a.Val, lvl - 1, fac).ToArray()}
                    })
                    .ToArray();
                return new Ul
                {
                    Subs = subs,
                    Itemscope = true,
                    Itemtype = itemtype,
                }.ToArray();
            }
        }
    }
