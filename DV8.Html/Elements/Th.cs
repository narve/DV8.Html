using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Th : HtmlElement
{
    public int? Colspan
    {
        get => GetInt("colspan");
        set => Set("colspan", value?.ToString());
    }    
    
    public Th()
    {
    }

    public Th(string r) : base(null, r)
    {
    }
}