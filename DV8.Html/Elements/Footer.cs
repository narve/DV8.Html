using System.Collections.Generic;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Footer : HtmlElement
{
    public Footer()
    {
    }

    public Footer(IEnumerable<IHtmlElement> htmlElements) : base(htmlElements)
    {
    }

    public Footer(params IHtmlElement[] htmlElements) : base(htmlElements)
    {
    }
}