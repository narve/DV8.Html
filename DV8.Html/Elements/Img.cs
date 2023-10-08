using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Img : HtmlElement
{
    public string? Src
    {
        get => Get("src");
        set => Set("src", value);
    }

    public string? Alt
    {
        get => Get("alt");
        set => Set("alt", value);
    }

    public Img(string src, string? alt = null)
    {
        Src = src;
        Alt = alt;
    }
}