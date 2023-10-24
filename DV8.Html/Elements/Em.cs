using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Em: HtmlElement
{
    protected override bool IsInlineBlock => true;
    public Em()
    {
    }
    
    public Em(string text) : base(null, text)
    {
    }
    
}