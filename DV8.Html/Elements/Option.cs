using DV8.Html.Framework;
// ReSharper disable PropertyCanBeMadeInitOnly.Global
// ReSharper disable MemberCanBePrivate.Global

namespace DV8.Html.Elements;

public class Option : HtmlElement
{
    [Attr] public string? Value 
    {
        get => Get("value");
        set => Set("value", value);
    }
        
    [Attr] public bool Selected 
    {
        get => GetBool("selected");
        set => SetBool("selected", value);
    }        

    [Attr] public bool Disabled
    {
        get => GetBool("disabled");
        set => SetBool("disabled", value);
    }        

    [Attr] public string? Tooltip
    {
        get => Get("tooltip");
        set => Set("tooltip", value);
    }
    

    public Option()
    {
    }

    public Option(string value, string? text = null): base(null, text) => 
        Value = value;

    public Option WithSelected(bool selected)
    {
        Selected = selected;
        return this;
    }
}