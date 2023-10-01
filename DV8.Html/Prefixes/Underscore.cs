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
            Subs = new List<IHtmlElement> { child }
        };

    public static T _<T>(params IHtmlElement[] children) where T : IHtmlElement, new() =>
        new()
        {
            Subs = children.ToList()
        };

    public static T _<T>(List<IHtmlElement> children) where T : IHtmlElement, new() =>
        new()
        {
            Subs = children
        };

    public static T _<T>(IEnumerable<IHtmlElement> children) where T : IHtmlElement, new() =>
        new()
        {
            Subs = children.ToList()
        };

    public static T _<T>(string text) where T : IHtmlElement, new()
    {
        var t = new T();
        if(!string.IsNullOrEmpty(text))
            t.Subs.Add(new TextContent(text));
        return t;
    }

    public static TextContent _(string text) =>
        new(text);

    public static UnsafeTextContent _UNSAFE(string text) =>
        new(text);
}