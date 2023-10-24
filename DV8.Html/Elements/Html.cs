using System.Xml;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Html : HtmlElement
{
    /// <summary>
    /// Adds a standard html 5 doc type prelude. 
    /// </summary>
    public override void WriteXml(XmlWriter writer)
    {
        writer.WriteRaw("<!DOCTYPE html>");
        base.WriteXml(writer);
    }

    /// <summary>
    /// Adds a standard html 5 doc type prelude. 
    /// </summary>
    public override void WriteHtml(HtmlWriter writer, string prefix = "")
    {
        writer.WriteRaw("<!DOCTYPE html>");
        base.WriteHtml(writer, prefix);
    }
}