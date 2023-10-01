using DV8.Html.Framework;

// ReSharper disable ArrangeAccessorOwnerBody

namespace DV8.Html.Elements;

public class Select : HtmlElement, IFormElement
{
    [Attr]
    public bool Multiple { get; set; } = false;

    public bool Disabled { get; set; }

    [Attr]
    public string Name { get; set; }

    [Attr]
    public object Size { get; set; }

    // [Attr]
    // public object Value
    // {
    //     get { return Subs.OfType<Option>().SingleOrDefault(o => o.Selected); }
    //     set
    //     {
    //         throw new ArgumentException("NYI");
    //     }
    // }

    [Attr]
    public bool Required { get; set; }
}