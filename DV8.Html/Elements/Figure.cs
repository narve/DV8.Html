using System.Collections.Generic;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Figure : HtmlElement
{
    public Figure()
    {
    }

    public Figure(IEnumerable<IHtmlElement> htmlElements) : base(htmlElements)
    {
    }

    public Figure(params IHtmlElement[] htmlElements) : base(htmlElements)
    {
    }

    public Figure(string caption, params IHtmlElement[] htmlElements) : base(htmlElements)
    {
        Add(new Figcaption(caption));
    }
}