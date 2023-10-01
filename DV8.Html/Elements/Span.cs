namespace DV8.Html.Elements;

public class Span : HtmlElement
{
    public Span()
    {
    }

    public Span(string s) => AddIfNotEmpty(s);
}