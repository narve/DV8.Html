using System.Xml;

namespace DV8.Html.Elements;

public class Html : HtmlElement
{
    public override void WriteHtml(XmlWriter writer)
    {
        // writer.WriteString("<!DOCTYPE html>");
        writer.WriteRaw("<!DOCTYPE html>");
        base.WriteHtml(writer);
    }
}