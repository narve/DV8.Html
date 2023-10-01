namespace DV8.Html.Elements;

public class P : HtmlElement
{
    public P()
    {
    }

    public P(string s) => AddIfNotEmpty(s);
}