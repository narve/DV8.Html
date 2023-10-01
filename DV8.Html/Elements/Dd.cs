namespace DV8.Html.Elements;

public class Dd : HtmlElement
{
    public Dd()
    {
    }

    public Dd(object text) => AddIfNotEmpty(text);
}