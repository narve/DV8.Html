using System.Net;
using System.Xml;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class TextContent : HtmlElement
{
    /// <summary>
    /// Gets or sets the text content to a new value that will be encoded when serializing.
    /// </summary>
    public string? Text { get; set; }

    public TextContent()
    {
        Text = "";
    }

    public TextContent(string textThatWillBeEncoded) => Text = textThatWillBeEncoded;

    public override void WriteXml(XmlWriter writer) => writer.WriteString(Text);
    public override void WriteHtml(HtmlWriter writer, string prefix = "") => writer.WriteRaw(WebUtility.HtmlEncode(Text));
}