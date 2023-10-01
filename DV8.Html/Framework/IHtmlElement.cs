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

    void WriteHtml(XmlWriter writer);
}