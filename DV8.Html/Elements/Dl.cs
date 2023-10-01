using System.Collections.Generic;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Dl : HtmlElement
{
    public Dl()
    {
    }

    public Dl(IEnumerable<IHtmlElement> subs) : base(subs)
    {
    }

    public Dl(params IHtmlElement[] subs) : base(subs)
    {
    }
}