// ReSharper disable ArrangeAccessorOwnerBody

namespace DV8.Html.Elements;

public class Textarea : HtmlElement, IFormElement
{
    [Attr]
    public bool Disabled { get; set; }

    [Attr]
    public string Name { get; set; }

    public object Value
    {
        get { return Text; }
        set { Text = value?.ToString(); }
    }

    [Attr]
    public bool Required { get; set; }

    [Attr]
    public Textarea Disable(bool d = true)
    {
        Disabled = d;
        return this;
    }
}