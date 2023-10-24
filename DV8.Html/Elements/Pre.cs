using DV8.Html.Framework;

// ReSharper disable UnusedType.Global

namespace DV8.Html.Elements;

public class Pre : HtmlElement
{
    protected override bool IsInlineBlock => true;

    public Pre()
    {
    }

    public Pre(string s) : base(null, s)
    {
    }
}