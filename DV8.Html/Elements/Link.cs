using DV8.Html.Framework;

// ReSharper disable UnusedType.Global

namespace DV8.Html.Elements;

public class Link : HtmlElement
{
    public static Link StylesheetLink(string href, string? media = null, string? crossOrigin = null) =>
        new()
        {
            Rel = "stylesheet",
            Href = href,
            Media = media,
            CrossOrigin = crossOrigin
        };

    public string? Rel
    {
        get => Get("rel");
        set => Set("rel", value);
    }


    public string? Href
    {
        get => Get("href");
        set => Set("href", value);
    }


    public string? Type
    {
        get => Get("type");
        set => Set("type", value);
    }


    public string? As
    {
        get => Get("as");
        set => Set("as", value);
    }


    public string? Sizes
    {
        get => Get("sizes");
        set => Set("sizes", value);
    }


    public string? Media
    {
        get => Get("media");
        set => Set("media", value);
    }


    public string? CrossOrigin
    {
        get => Get("crossorigin");
        set => Set("crossorigin", value);
    }
}