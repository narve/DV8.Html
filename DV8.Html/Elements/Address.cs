using System.Collections.Generic;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Address: HtmlElement
{
    public Address()
    {
    }

    public Address(string text): base(text: text)
    {
    }

    public Address(IEnumerable<IHtmlElement> htmlElements) : base(htmlElements)
    {
    }

    public Address(params IHtmlElement[] htmlElements) : base(htmlElements)
    {
    }
}