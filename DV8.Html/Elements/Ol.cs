using System.Collections.Generic;
using DV8.Html.Framework;
// ReSharper disable UnusedType.Global

namespace DV8.Html.Elements;

public class Ol : HtmlElement
{
    public Ol()
    {
    }

    public Ol(IEnumerable<IHtmlElement> htmlElements) : base(htmlElements)
    {
    }

    public Ol(string? tagName = null, string? text = null) : base(tagName, text)
    {
    }
}