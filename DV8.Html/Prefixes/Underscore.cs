using System.Collections.Generic;
using System.Linq;
using DV8.Html.Elements;

namespace DV8.Html.Prefixes;

public static class Underscore
{
    public static T _<T>() where T : IHtmlElement, new() => new();

    public static T _<T>(IHtmlElement child) where T : IHtmlElement, new() =>
        new()
        {
            Subs = new[] { child }
        };

    public static T _<T>(params IHtmlElement[] children) where T : IHtmlElement, new() =>
        new()
        {
            Subs = children
        };

    public static T _<T>(IEnumerable<IHtmlElement> children) where T : IHtmlElement, new() =>
        new()
        {
            Subs = children.ToArray()
        };

    public static T _<T>(string text) where T : IHtmlElement, new() =>
        new()
        {
            Text = text
        };

    public static TextContent _(string text) =>
        new(text);

    public static RawTextContent _UNSAFE(string text) =>
        new(text);
}