using System.Collections.Generic;
using System.Web;

namespace DV8.Html.Elements;

public class TextContent : HtmlElement
{
    public TextContent()
    {
    }

    public TextContent(string text) => Text = HttpUtility.HtmlEncode(text);

    public override string ToHtml() => Text;
}