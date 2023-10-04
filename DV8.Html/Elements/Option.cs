using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Option : HtmlElement
{
    [Attr] public object Value { get; set; }
    [Attr] public bool Selected { get; set; }

    [Attr] public bool Disabled { get; set; }

    [Attr] public string Tooltip { get; set; }

    public Option()
    {
    }

    public Option(string value, string text = null): base(null, text) => 
        Value = value;

    public Option WithSelected(bool selected)
    {
        Selected = selected;
        return this;
    }
}