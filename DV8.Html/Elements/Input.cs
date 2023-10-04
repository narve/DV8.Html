using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Input : HtmlElement, IFormElement
{
    protected override bool AutoClose => false;
    
    [Attr]
    public bool Disabled { get; set; }

    [Attr]
    public string Name { get; set; }

    [Attr]
    public string Pattern { get; set; }
        
    /// <summary>
    /// Seconds (for time at least)
    /// </summary>
    [Attr]
    public int? Step { get; set; }

    [Attr]
    public string PlaceHolder { get; set; }

    [Attr("type")]
    public object InputType { get; set; } = "text";

    [Attr]
    public object Value { get; set; }

    [Attr]
    public bool Checked { get; set; }

    [Attr]
    public bool Readonly { get; set; }

    [Attr]
    public bool Required { get; set; }


    public Input Disable(bool d = true)
    {
        if (!d) return this;
        Clz += " disabled";
        Disabled = true;
        return this;
    }

    
    public static Input ForString(string name, string value = null) => new Input
    {
        Id = name,
        Name = name,
        PlaceHolder = name,
        Value = value,
    };
}