namespace DV8.Html.Elements;

public class Dt : HtmlElement
{
    public Dt()
    {
    }

    public Dt(object text) => AddIfNotEmpty(text);
}