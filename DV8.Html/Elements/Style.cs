using System;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Style : HtmlElement
{
    [Attr] public string? Media 
    {
        get => Get("media");
        set => Set("media", value);
    }

    [Attr] public string? Nonce 
    {
        get => Get("nonce");
        set => Set("nonce", value);
    }

    [Attr] public string? Blocking 
    {
        get => Get("blocking");
        set => Set("blocking", value);
    }


    [Obsolete]
    public string Type 
    {
        get => Get("type");
        set => Set("type", value);
    }
    


    /// <summary>
    /// NB this constructor does not escape unsafe content
    /// </summary>
    /// <param name="unsafeContent"></param>
    public Style(string unsafeContent)
    {
        if (!string.IsNullOrEmpty(unsafeContent))
            Children.Add(new UnsafeTextContent(unsafeContent));
    }
}