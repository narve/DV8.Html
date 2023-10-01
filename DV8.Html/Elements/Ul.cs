using System.Collections.Generic;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Ul : HtmlElement
{
    public Ul()
    {
    }

    public Ul(IEnumerable<IHtmlElement> subs) : base(subs)
    {
    }
}