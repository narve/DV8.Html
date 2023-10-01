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
    /// <param name="txt"></param>
    public HtmlElement(string? tagName = null, string? txt = null)
    {
        Tag = tagName ?? GetTag();
        AddIfNotEmpty(txt);
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

    public virtual void WriteHtml(XmlWriter writer)
    {
        writer.WriteStartElement(GetTag());
        WriteAttributes(writer);
        foreach (var o in Subs ?? new())
        {
            o.WriteHtml(writer);
        }
        //
        // foreach (var pi in GetType().GetProperties())
        // {
        //     if (!Attribute.IsDefined(pi, typeof(Attr)) && !pi.Name.Equals(nameof(Subs)) &&
        //         // !pi.Name.Equals(nameof(Text)) &&
        //         !pi.Name.Equals(nameof(Tag))
        //        )
        //     {
        //         if (pi.GetValue(this) is HtmlElement val)
        //         {
        //             // writer.WriteLine(val.ToHtml());
        //             val.WriteHtml(writer);
        //         }
        //     }
        // }
        //
        writer.WriteEndElement();
        writer.Flush();
    }

    private void WriteAttributes(XmlWriter writer)
    {
        foreach (var pi in DefinedAttributes().Where(AttributeHasValue))
        {
            var a = (Attr)pi.GetCustomAttribute(typeof(Attr))!;
            var attrName = a.name ?? pi.Name.ToLower();
            var val =
                pi.PropertyType == typeof(bool) ? attrName : pi.GetValue(this)!;
            // writer.WriteStartAttribute(attrName);
            writer.WriteAttributeString(attrName, val.ToString());
            // writer.WriteEndAttribute();
            // WriteAttribute(writer, attrName, val);
        }

        foreach (var (key, value) in ExAttributes ?? new Dictionary<string, string>())
        {
            writer.WriteAttributeString(key, value);
            // WriteAttribute(writer, key, value);
        }
    }
    //
    // public static void WriteAttribute(TextWriter writer, string attrName, object val)
    // {
    //     writer.Write(" ");
    //
    //     if (val is bool b && b)
    //     {
    //         writer.Write(attrName);
    //         writer.Write("='");
    //         writer.Write(attrName);
    //         writer.Write('\'');
    //     }
    //     else
    //     {
    //         writer.Write(attrName);
    //         writer.Write("='");
    //         writer.Write(val);
    //         writer.Write('\'');
    //     }
    //
    //     writer.Flush();
    // }

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
        // writer.Write("hei");
        var settings = new XmlWriterSettings
        {
            Indent = true,
            IndentChars = "  ",
            ConformanceLevel = ConformanceLevel.Auto,
        };
        using var xml = XmlWriter.Create(writer, settings);
        WriteHtml(xml);
        // writer.Write("hadet");
        return writer.ToString();
    }
}