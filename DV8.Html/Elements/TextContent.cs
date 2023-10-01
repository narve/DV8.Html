using System.Xml;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class TextContent : HtmlElement
{
    /// <summary>
    /// Gets or sets the text content to a new value that will be encoded when serializing.
    /// </summary>
    public string Text { get; set; }

    public TextContent()
    {
    }

    public TextContent(string textThatWillBeEncoded) => Text = textThatWillBeEncoded;

    public override void WriteHtml(XmlWriter writer) => writer.WriteString(Text);
}