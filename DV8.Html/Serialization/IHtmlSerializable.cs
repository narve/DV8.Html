using System.Collections.Generic;
using DV8.Html.Framework;

namespace DV8.Html.Serialization;

/// <summary>
/// Implement this
/// </summary>
public interface IHtmlSerializable
{
    IEnumerable<IHtmlElement> Serialize(int lvl, IHtmlSerializer fac);

    // public string ToHtml();
    // {
        // using var writer = new StringWriter();
        // using var xml = XmlWriter.Create(writer);
        // WriteHtml(xml);
        // return writer.ToString();
    // }
    // void WriteHtml(XmlWriter writer);
}