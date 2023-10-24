using System.Xml;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class UnsafeTextContent : HtmlElement
{
    /// <summary>
    /// Gets or sets a text that will NOT be encoded when serializing
    /// </summary>
    public string Text { get; set; }

    public UnsafeTextContent()
    {
        Text = "";
    }

    public UnsafeTextContent(string text) => Text = text;

    public override void WriteXml(XmlWriter writer) => writer.WriteRaw(Text);
    public override void WriteHtml(HtmlWriter writer, string prefix = "") => writer.WriteRaw(Text);
}