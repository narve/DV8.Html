#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using DV8.Html.Elements;
using DV8.Html.Serialization;

// ReSharper disable CollectionNeverUpdated.Global

// ReSharper disable ArrangeRedundantParentheses

namespace DV8.Html.Framework;

public class HtmlElement : IHtmlElement
{
    protected virtual bool AutoClose => true;
    
    [Attr] public string? Id { get; set; }

    [Attr] public string? Style { get; set; }

    [Attr] public string? Title { get; set; }

    [Attr("class")] public string? Clz { get; set; }

    [Attr] public bool Itemscope { get; set; }

    [Attr] public string? Itemtype { get; set; }

    [Attr] public string? Itemprop { get; set; }

    public string Tag { get; }

    public IDictionary<string, string> ExAttributes = new Dictionary<string, string>();


    public List<IHtmlElement> Subs { get; set; } = new();

    public HtmlElement()
    {
        Tag = GetTag();
    }

    public HtmlElement(IEnumerable<IHtmlElement> htmlElements)
    {
        Tag = GetTag();
        Subs.AddRange(htmlElements);
    }

    /// <summary>
    /// Creates a new HtmlElement with the given tag name and optional text content.
    /// </summary>
    /// <param name="tagName">defaults to the lower case name of the class</param>
    /// <param name="text"></param>
    public HtmlElement(string? tagName = null, string? text = null)
    {
        Tag = tagName ?? GetTag();
        AddIfNotEmpty(text);
    }


    protected void AddIfNotEmpty(object? txt)
    {
        if (txt != null)
        {
            var s = txt.ToString();
            if (!string.IsNullOrEmpty(s))
                Subs.Add(new TextContent(txt.ToString()));
        }
    }
    
    public string GetTag()
        => Tag?.ToLower() ?? GetType().Name.ToLower();
    
    public IHtmlElement[] ToArray() => new IHtmlElement[] { this };
    public List<IHtmlElement> ToList() => new() { this };

    public virtual void WriteHtml(HtmlWriter writer)
    {
        writer.WriteStartOfElement(GetTag());
        WriteAttributes(writer);
        writer.WriteEndOfElementTag();
        foreach (var o in Subs ?? new())
        {
            o.WriteHtml(writer);
        }
        if (AutoClose)
            writer.WriteEndElement(GetTag());
    }
    
    public virtual void WriteXml(XmlWriter writer)
    {
        writer.WriteStartElement(GetTag());
        WriteAttributes(writer);
        foreach (var o in Subs ?? new())
        {
            o.WriteXml(writer);
        }
        writer.WriteEndElement();
    }

    private void WriteAttributes(HtmlWriter writer)
    {
        foreach (var (key, value) in ExtractAttributes())
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
        foreach (var pi in DefinedAttributes().Where(AttributeHasValue))
        {
            var a = (Attr)pi.GetCustomAttribute(typeof(Attr))!;
            var attrName = a.Name ?? pi.Name.ToLower();
            var val = pi.PropertyType == typeof(bool) 
                ? attrName 
                : pi.GetValue(this)!;
            dict.Add(attrName, val.ToString()!);
        }

        foreach (var (key, value) in ExAttributes ?? new Dictionary<string, string>())
        {
            dict.Add(key, value);
        }

        return dict;
    }

    public bool AttributeHasValue(PropertyInfo pi)
    {
        var value = pi.GetValue(this);
        return value != null && (pi.PropertyType != typeof(bool) || (bool)value!);
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