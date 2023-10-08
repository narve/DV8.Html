using DV8.Html.Framework;
// ReSharper disable UnusedType.Global

namespace DV8.Html.Elements;

public class Meta: HtmlElement
{
    
    public string? Charset
    {
        get => Get("charset");
        set => Set("charset", value);
    }
    
}