using System.Collections.Generic;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Div : HtmlElement
{
    public Div()
    {
    }

    public Div(IEnumerable<IHtmlElement> subs) : base(subs)
    {
    }

    public Div(params IHtmlElement[]subs) : base(subs)
    {
    }
}