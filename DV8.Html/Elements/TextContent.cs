using System.Net;
using System.Xml;

namespace DV8.Html.Elements;

public class TextContent : HtmlElement
{
    private string _text;

    /// <summary>
    /// Gets the encoded text, or sets the text content to a new value THAT WILL BE ENCODED.
    /// </summary>
    public string Text
    {
        get => _text;
        set => _text = WebUtility.HtmlEncode(value);
    }

    public TextContent()
    {
    }

    public TextContent(string textThatWillBeEncoded) => _text = textThatWillBeEncoded;

    public override void WriteHtml(XmlWriter writer) => writer.WriteString(Text);
}