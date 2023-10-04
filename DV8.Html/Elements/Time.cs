using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Time : HtmlElement
{
    [Attr] public string? Datetime
    {
        get => Get("datetime");
        set => Set("datetime", value);
    }
    

    public Time(string isoVersion, string textVersion = null): base(null, textVersion??isoVersion)
    {
        Datetime = isoVersion;
    }
}