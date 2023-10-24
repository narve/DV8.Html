using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class P : HtmlElement
{
    protected override bool IsInlineBlock => true;

    public P()
    {
    }

    public P(string s) : base(null, s)
    {
    }

    // protected P(params IHtmlElement[] htmlElements) : base(htmlElements)
    // {
    // }
    //
    // public P(string text, params IHtmlElement[] htmlElements) : base(null, htmlElements)
    // {
    // }
}