using System;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Style : HtmlElement
{
    [Attr] public string Media { get; set; }
    [Attr] public string Nonce { get; set; }
    [Attr] public string Blocking { get; set; }

    [Obsolete]
    public string Type { get; set; }


    /// <summary>
    /// NB this content does not escape unsafe content
    /// </summary>
    /// <param name="unsafeContent"></param>
    public Style(string unsafeContent)
    {
        if (!string.IsNullOrEmpty(unsafeContent))
            Subs.Add(new UnsafeTextContent(unsafeContent));
    }
}