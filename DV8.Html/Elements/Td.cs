using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Td : HtmlElement
{
    [Attr("data-sortvalue")]
    public string DataSortValue { get; set; }

    public Td()
    {
    }

    public Td(string text) : base(null, text)
    {
    }
}