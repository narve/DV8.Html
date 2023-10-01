// ReSharper disable ArrangeAccessorOwnerBody

namespace DV8.Html.Elements;

public class Textarea : HtmlElement, IFormElement
{
    [Attr]
    public bool Disabled { get; set; }

    [Attr]
    public string Name { get; set; }
    
    [Attr]
    public bool Required { get; set; }

    [Attr]
    public Textarea Disable(bool d = true)
    {
        Disabled = d;
        return this;
    }
}