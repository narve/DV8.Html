using System.Collections.Generic;
using System.Xml;
using DV8.Html.Serialization;

// ReSharper disable UnusedMemberInSuper.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global

namespace DV8.Html.Framework;

public interface IHtmlElement : IHtmlSerializable
{
    // ******** Global attributes ***/

    string? Id { get; set; }

    string? Class { get; set; }

    string? Title { get; set; }

    string? Style { get; set; }

    string? Tag { get; }

    List<IHtmlElement> Children { get; set; }


    public string ToHtml();
    public string ToXml();

    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    /// <summary>
    /// Element attributes. Included in HTML. Using this dictionary directly
    /// bypasses validation of attribute names and values.
    /// Setting value to null or empty string removes the attribute
    /// from generated html. Note that boolean values are handled explicitly,
    /// use SetBool for those.  
    /// </summary>
    public IDictionary<string, string> Attributes { get; }

    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    /// <summary>
    /// Element properties. Not included in HTML. Use this for whatever you want.  
    /// </summary>
    public IDictionary<string, object> Properties { get; }


    /// <returns>self</returns>
    public IHtmlElement Add(params IHtmlElement[] children)
    {
        Children.AddRange(children);
        return this;
    }

    /// <returns>self</returns>
    public IHtmlElement Add(IEnumerable<IHtmlElement> children)
    {
        Children.AddRange(children);
        return this;
    }

    void WriteXml(XmlWriter writer);
    void WriteHtml(HtmlWriter writer, string prefix = "");
}