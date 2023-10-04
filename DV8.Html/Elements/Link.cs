using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Link : HtmlElement
{

    [Attr]
    public string? Rel
    {
        get => Get("rel");
        set => Set("rel", value);
    }


    [Attr]
    public string? Href
    {
        get => Get("href");
        set => Set("href", value);
    }


    [Attr]
    public string? Type
    {
        get => Get("type");
        set => Set("type", value);
    }


    [Attr]
    public string? As
    {
        get => Get("as");
        set => Set("as", value);
    }


    [Attr]
    public string? Sizes
    {
        get => Get("sizes");
        set => Set("sizes", value);
    }


    [Attr]
    public string? Media
    {
        get => Get("media");
        set => Set("media", value);
    }


    [Attr]
    public string? CrossOrigin
    {
        get => Get("crossorigin");
        set => Set("crossorigin", value);
    }
}