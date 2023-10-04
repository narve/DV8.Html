using System.Collections.Generic;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Head : HtmlElement
{
    public Head()
    {
    }

    public Head(IEnumerable<IHtmlElement> htmlElements) : base(htmlElements)
    {
    }
    
    public Head(params IHtmlElement[] htmlElements) : base(htmlElements)
    {
    }
}