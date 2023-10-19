using System.Collections.Generic;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Article : HtmlElement
{
    public Article()
    {
    }

    public Article(IEnumerable<IHtmlElement> htmlElements) : base(htmlElements)
    {
    }

    public Article(params IHtmlElement[] htmlElements) : base(htmlElements)
    {
    }
}