

// ReSharper disable InconsistentNaming

namespace DV8.Html.Elements;

public abstract class Linking : HtmlElement
{
    [Attr]
    public string rel { get; set; }

    [Attr("data-disabled")]
    public bool Disabled { get; set; }

    public abstract A ToAnchor(string _href = null);
}