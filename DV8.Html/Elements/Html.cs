using System.Xml;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Html : HtmlElement
{
    /// <summary>
    /// Adds a standard html 5 doc type prelude. 
    /// </summary>
    public override void WriteHtml(XmlWriter writer)
    {
        writer.WriteRaw("<!DOCTYPE html>");
        base.WriteHtml(writer);
    }
}