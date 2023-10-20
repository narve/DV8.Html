using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Td : HtmlElement
{
    public int? Colspan
    {
        get => GetInt("colspan");
        set => Set("colspan", value?.ToString());
    }    
    
    public Td()
    {
    }

    public Td(string text) : base(null, text)
    {
    }
}