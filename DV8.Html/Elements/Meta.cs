using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Meta: HtmlElement
{
    [Attr]
    public string Charset
    {
        get => Get("charset");
        set => Set("charset", value);
    }
    
}