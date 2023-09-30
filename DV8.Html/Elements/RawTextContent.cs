using System.Collections.Generic;
using System.Web;

namespace DV8.Html.Elements;

public class RawTextContent : HtmlElement
{
    public RawTextContent()
    {
    }

    public RawTextContent(string text) => Text = text;

    public override string ToHtml() => Text;
}