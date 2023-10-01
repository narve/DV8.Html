using System.Collections.Generic;
using System.Web;
using System.Xml;

namespace DV8.Html.Elements;

public class UnsafeTextContent : HtmlElement
{
    public string Text { get; set; }

    public UnsafeTextContent()
    {
    }

    public UnsafeTextContent(string text) => Text = text;

    public override void WriteHtml(XmlWriter writer) => writer.WriteRaw(Text);
}