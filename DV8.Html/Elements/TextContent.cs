// using System.Web;

using System.Net;

namespace DV8.Html.Elements;

public class TextContent : HtmlElement
{
    public TextContent()
    {
    }

    public TextContent(string text) => Text = WebUtility.HtmlEncode(text);

    public override string ToHtml() => Text;
}