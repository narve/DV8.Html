using System.Collections.Generic;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Body : HtmlElement
{
    public Body()
    {
    }

    public Body(IEnumerable<IHtmlElement> subs) : base(subs)
    {
    }

    public Body(params IHtmlElement[] subs) : base(subs)
    {
    }
}