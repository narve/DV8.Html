using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Span : HtmlElement
{
    protected override bool IsInlineBlock => true;
    public Span()
    {
    }

    public Span(string? text) : base(null, text)
    {
    }
}