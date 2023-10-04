using System.Collections.Generic;
using System.Xml;
using DV8.Html.Serialization;

namespace DV8.Html.Framework;

public interface IHtmlElement : IHtmlSerializable
{
    // ******** Global attributes ***/
    [Attr]
    string? Id { get; set; }

    [Attr("class")]
    string? Clz { get; set; }
    
    string? Title { get; set; }
    
    [Attr]
    string? Style { get; set; }


    string? Tag { get; }
    List<IHtmlElement> Children { get; set; }

    public string ToHtml();
    public string ToXml();

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
    void WriteHtml(HtmlWriter writer);
}