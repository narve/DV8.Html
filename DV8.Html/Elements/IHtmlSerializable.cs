using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace DV8.Html.Elements;

public interface IHtmlSerializable
{
    IEnumerable<IHtmlElement> Serialize(int lvl, IHtmlSerializer fac);

    public string ToHtml();
    // {
        // using var writer = new StringWriter();
        // using var xml = XmlWriter.Create(writer);
        // WriteHtml(xml);
        // return writer.ToString();
    // }
    void WriteHtml(XmlWriter writer);
}