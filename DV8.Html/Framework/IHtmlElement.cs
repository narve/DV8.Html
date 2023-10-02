using System.Collections.Generic;
using System.Xml;
using DV8.Html.Serialization;

namespace DV8.Html.Framework;

public interface IHtmlElement : IHtmlSerializable
{
    [Attr]
    string Id { get; set; }

    [Attr]
    string Style { get; set; }

    [Attr("class")]
    string Clz { get; set; }

    List<IHtmlElement> Subs { get; set; }

    string Tag { get; }

    string Title { get; set; }

    public string ToHtml();
    public string ToXml();

    /// <returns>self</returns>
    public IHtmlElement Add(params IHtmlElement[] children)
    {
        Subs.AddRange(children);
        return this;
    }

    /// <returns>self</returns>
    public IHtmlElement Add(IEnumerable<IHtmlElement> children)
    {
        Subs.AddRange(children);
        return this;
    }
    
    void WriteXml(XmlWriter writer);
    void WriteHtml(HtmlWriter writer);
}