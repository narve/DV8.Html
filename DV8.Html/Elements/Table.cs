using System.Collections.Generic;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Table : HtmlElement
{
    public string? Name
    {
        get => Get("name");
        set => Set("name", value);
    }

    public Table()
    {
    }

    public Table(IEnumerable<IHtmlElement> htmlElements) : base(htmlElements)
    {
    }

    public Table(string? tagName = null, string? text = null) : base(tagName, text)
    {
    }
}