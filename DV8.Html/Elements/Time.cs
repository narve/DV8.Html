namespace DV8.Html.Elements;

public class Time : HtmlElement
{
    [Attr] public string Datetime { get; set; }

    public Time(string isoVersion, string textVersion = null)
    {
        Datetime = isoVersion;
        Text = textVersion ?? isoVersion;
    }
}