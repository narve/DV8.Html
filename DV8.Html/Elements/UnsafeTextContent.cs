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
    }

    public UnsafeTextContent(string text) => Text = text;

    public override void WriteHtml(XmlWriter writer) => writer.WriteRaw(Text);
}