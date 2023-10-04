using DV8.Html.Framework;

// ReSharper disable ArrangeAccessorOwnerBody

namespace DV8.Html.Elements;

public class Select : HtmlElement, IFormElement
{
    [Attr]
    public bool Multiple 
    {
        get => GetBool("multiple");
        set => SetBool("multiple", value);
    }


    public bool Disabled 
    {
        get => GetBool("disabled");
        set => SetBool("disabled", value);
    }
        

    [Attr]
    public string? Name 
    {
        get => Get("name");
        set => Set("name", value);
    }
        

    [Attr]
    public string? Size
    {
        get => Get("size");
        set => Set("size", value);
    }
        

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