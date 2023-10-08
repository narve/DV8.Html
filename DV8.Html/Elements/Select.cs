using DV8.Html.Framework;

// ReSharper disable ClassNeverInstantiated.Global

// ReSharper disable ArrangeAccessorOwnerBody

namespace DV8.Html.Elements;

public class Select : InputElement, IFormElement
{
    public bool Multiple
    {
        get => GetBool("multiple");
        set => SetBool("multiple", value);
    }

    public string? Size
    {
        get => Get("size");
        set => Set("size", value);
    }
}