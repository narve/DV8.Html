using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Table : HtmlElement
{
    public string? Name
    {
        get => Get("name");
        set => Set("name", value);
    }
}