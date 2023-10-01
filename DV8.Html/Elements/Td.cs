namespace DV8.Html.Elements;

public class Td : HtmlElement
{
    [Attr("data-sortvalue")]
    public string DataSortValue { get; set; }

    public Td()
    {
    }

    public Td(object text) => AddIfNotEmpty(text);
}