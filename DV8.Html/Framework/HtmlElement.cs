using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using DV8.Html.Elements;
using DV8.Html.Serialization;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable UnusedMember.Global

// ReSharper disable CollectionNeverUpdated.Global

// ReSharper disable ArrangeRedundantParentheses

namespace DV8.Html.Framework;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class HtmlElement : IHtmlElement
{
    /// <summary>
    /// Indicates whether this element is closable (like `div`) or not (like `input`)
    /// </summary>
    protected virtual bool AutoClose => true;

    [Attr]
    public string? Id
    {
        get => Get("id");
        set => Set("id", value);
    }

    [Attr] public string? Style
    {
        get => Get("style");
        set => Set("style", value);
    }

    [Attr] public string? Title
    {
        get => Get("title");
        set => Set("title", value);
    }

    [Attr("class")] public string? Clz 
    {
        get => Get("class");
        set => Set("class", value);
    }

    [Attr] public bool Itemscope 
    {
        get => GetBool("itemscope");
        set => SetBool("itemscope", value);
    }

    [Attr] public string? Itemtype 
    {
        get => Get("itemtype");
        set => Set("itemtype", value);
    }

    [Attr] public string? Itemprop 
    {
        get => Get("itemprop");
        set => Set("itemprop", value);
    }

    protected string? Get(string attributeName) =>
        Attributes.TryGetValue(attributeName, out var s)
            ? s
            : null;

    public bool GetBool(string attributeName) =>
        Get(attributeName) != null;

    public void SetBool(string attributeName, bool value)
    {
        var key = attributeName.ToLower();
        if (value)
            Set(key, key);
        else 
            Attributes.Remove(key);
    }

    public void Set(string attributeName, string? value)
    {
        if (value == null)
            Attributes.Remove(attributeName);
        else
            Attributes[attributeName] = value;
    }


    public string Tag { get; }

    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    public IDictionary<string, string> Attributes = new Dictionary<string, string>();

    public IHtmlElement Add(params IHtmlElement[] children)
    {
        Children.AddRange(children);
        return this;
    }

    public IHtmlElement Add(IEnumerable<IHtmlElement> children)
    {
        Children.AddRange(children);
        return this;
    }

    public List<IHtmlElement> Children { get; set; } = new();

    public HtmlElement()
    {
        Tag = GetDefaultTag();
    }

    public HtmlElement(IEnumerable<IHtmlElement> htmlElements)
    {
        Tag = GetDefaultTag();
        Children.AddRange(htmlElements);
    }

    /// <summary>
    /// Creates a new HtmlElement with the given tag name and optional text content.
    /// </summary>
    /// <param name="tagName">defaults to the lower case name of the class</param>
    /// <param name="text"></param>
    public HtmlElement(string? tagName = null, string? text = null)
    {
        Tag = tagName ?? GetDefaultTag();
        AddIfNotEmpty(text);
    }


    protected void AddIfNotEmpty(object? txt)
    {
        if (txt != null)
        {
            var s = txt.ToString();
            if (!string.IsNullOrEmpty(s))
                Children.Add(new TextContent(s));
        }
    }

    public string GetDefaultTag()
        => GetType().Name.ToLower();

    public IHtmlElement[] ToArray() => new IHtmlElement[] { this };
    public List<IHtmlElement> ToList() => new() { this };

    public virtual void WriteHtml(HtmlWriter writer)
    {
        writer.WriteStartOfElement(Tag);
        WriteAttributes(writer);
        writer.WriteEndOfElementTag();
        foreach (var o in Children)
        {
            o.WriteHtml(writer);
        }

        if (AutoClose)
            writer.WriteEndElement(Tag);
    }

    public virtual void WriteXml(XmlWriter writer)
    {
        writer.WriteStartElement(Tag);
        WriteAttributes(writer);
        foreach (var o in Children)
        {
            o.WriteXml(writer);
        }

        writer.WriteEndElement();
    }

    private void WriteAttributes(HtmlWriter writer)
    {
        foreach (var (key, value) in ExtractAttributes().ToImmutableSortedDictionary())
            writer.WriteAttributeString(key, value);
    }

    private void WriteAttributes(XmlWriter writer)
    {
        foreach (var (key, value) in ExtractAttributes())
            writer.WriteAttributeString(key, value);
    }

    protected Dictionary<string, string> ExtractAttributes()
    {
        var dict = new Dictionary<string, string>();
        // foreach (var pi in DefinedAttributes().Where(AttributeHasValue))
        // {
        //     var a = (Attr)pi.GetCustomAttribute(typeof(Attr))!;
        //     var attrName = a.Name ?? pi.Name.ToLower();
        //     var val = pi.PropertyType == typeof(bool)
        //         ? attrName
        //         : pi.GetValue(this)!;
        //     dict.Add(attrName, val.ToString()!);
        // }

        foreach (var (key, value) in Attributes)
        {
            dict.Add(key, value);
        }

        return dict;
    }

    public bool AttributeHasValue(PropertyInfo pi)
    {
        var value = pi.GetValue(this);
        return value != null && (pi.PropertyType != typeof(bool) || (bool)value);
    }

    public IEnumerable<PropertyInfo> DefinedAttributes() =>
        GetType().GetProperties().Where(pi => Attribute.IsDefined(pi, typeof(Attr)));

    public override string ToString() => Tag;

    public IEnumerable<IHtmlElement> Serialize(int lvl, IHtmlSerializer fac) => ToArray();

    public string ToHtml()
    {
        using var writer = new StringWriter();
        using var htmlWriter = new HtmlWriter(writer);
        WriteHtml(htmlWriter);
        return writer.ToString();
    }

    public string ToXml()
    {
        using var writer = new StringWriter();
        var settings = new XmlWriterSettings
        {
            Indent = true,
            IndentChars = "  ",
            ConformanceLevel = ConformanceLevel.Auto,
        };
        using var xmlWriter = XmlWriter.Create(writer, settings);
        WriteXml(xmlWriter);
        xmlWriter.Flush();
        return writer.ToString();
    }
}