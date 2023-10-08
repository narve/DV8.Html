using DV8.Html.Framework;
// ReSharper disable PropertyCanBeMadeInitOnly.Global
// ReSharper disable MemberCanBePrivate.Global

namespace DV8.Html.Elements;

public class Option : HtmlElement
{
     public string? Value 
    {
        get => Get("value");
        set => Set("value", value);
    }
        
     public bool Selected 
    {
        get => GetBool("selected");
        set => SetBool("selected", value);
    }        

     public bool Disabled
    {
        get => GetBool("disabled");
        set => SetBool("disabled", value);
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