using System.Collections.Generic;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Header : HtmlElement
{
    public Header()
    {
    }

    public Header(IEnumerable<IHtmlElement> htmlElements) : base(htmlElements)
    {
    }

    public Header(params IHtmlElement[] htmlElements) : base(htmlElements)
    {
    }
}