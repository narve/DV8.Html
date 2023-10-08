using System.Collections.Generic;
using DV8.Html.Framework;
// ReSharper disable PropertyCanBeMadeInitOnly.Global

namespace DV8.Html.Elements;

public class Input : InputElement, IFormElement
{
    protected override bool IsSelfClosing => true;

    
    public string? Pattern
    {
        get => Get("pattern");
        set => Set("pattern", value);
    }

    /// <summary>
    /// Seconds (for time at least)
    /// </summary>
    
    public int? Step { get; set; }

    
    public string? PlaceHolder
    {
        get => Get("placeholder");
        set => Set("placeholder", value);
    }

    public string Type
    {
        get => Get("type")!;
        set => Set("type", string.IsNullOrEmpty(value) ? "text" : value);
    }

     public string? Value 
    {
        get => Get("value")!;
        set => Set("value", string.IsNullOrEmpty(value) ? "text" : value);
    }

     public bool Checked
    {
        get => GetBool("checked");
        set => SetBool("checked", value);
    }        

     public bool Readonly
    {
        get => GetBool("readonly");
        set => SetBool("readonly", value);
    }        


    public Input Disable(bool d = true)
    {
        if (!d) return this;
        Class += " disabled";
        Disabled = true;
        return this;
    }

    public Input()
    {
        // InputType = "text";
    }

    public Input(IEnumerable<IHtmlElement> htmlElements) : base(htmlElements)
    {
        // InputType = "text";
    }

    public Input(string? tagName = null, string? text = null) : base(tagName, text)
    {
        // InputType = "text";
    }

    public static Input ForString(string? name, string? value = null) => new()
    {
        Id = name,
        Name = name,
        PlaceHolder = name,
        Type = "text",
        Value = value,
    };
}