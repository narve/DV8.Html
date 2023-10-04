using System;
using System.Linq;
using DV8.Html.Elements;
using DV8.Html.Framework;
using DV8.Html.Serialization;

namespace DV8.Html.Accessors;

public static class ElementAccessors
{
    public static string GetTextContent(this IHtmlSerializable e) =>
        e switch
        {
            TextContent tc => tc.Text,
            UnsafeTextContent utc => utc.Text,
            IHtmlElement h => string.Join("", h.Children.Select(sub => sub.GetTextContent())),
            _ => throw new ArgumentOutOfRangeException(nameof(e), e, null)
        };
}