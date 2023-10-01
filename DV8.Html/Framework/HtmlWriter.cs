using System;
using System.IO;
using System.Xml;

namespace DV8.Html.Framework;

public class HtmlWriter : IDisposable
{
    private readonly TextWriter _writer;

    public HtmlWriter(TextWriter writer) => _writer = writer;

    public void WriteStartOfElement(string tag)
    {
        _writer.Write('<' + tag);
    }

    public void WriteEndOfElementTag()
    {
        _writer.Write('>');
    }

    public void WriteAttributeString(string key, string value)
    {
        _writer.Write(' ' + key + "='" + value + '\'');
    }

    public void WriteEndElement(string tag)
    {
        _writer.Write("</" + tag + ">");
    }

    public void Dispose()
    {
    }

    public void WriteRaw(string text)
    {
        _writer.Write(text);
    }
}