namespace DV8.Html.Elements;

public class Style: HtmlElement
{
    public Style(string unsafeContent)
    {
        AddIfNotEmpty(unsafeContent);
    }
        
}