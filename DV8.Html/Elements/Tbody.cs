using System.Collections.Generic;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Tbody : HtmlElement
{
    public Tbody()
    {
    }

    public Tbody(IEnumerable<IHtmlElement> htmlElements) : base(htmlElements)
    {
    }

    public Tbody(string? tagName = null, string? text = null) : base(tagName, text)
    {
    }
}