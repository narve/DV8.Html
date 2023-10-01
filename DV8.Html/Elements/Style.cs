using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Style : HtmlElement
{
    /// <summary>
    /// NB this content does not escape unsafe content
    /// </summary>
    /// <param name="unsafeContent"></param>
    public Style(string unsafeContent)
    {
        if (!string.IsNullOrEmpty(unsafeContent))
            Subs.Add(new UnsafeTextContent(unsafeContent.ToString()));
    }
}