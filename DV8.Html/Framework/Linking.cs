

// ReSharper disable InconsistentNaming

using DV8.Html.Elements;

namespace DV8.Html.Framework;

public abstract class Linking : HtmlElement
{
    [Attr]
    public string rel { get; set; }

    [Attr("data-disabled")]
    public bool Disabled { get; set; }

    protected Linking()
    {
    }

    protected Linking(string tagName = null, string txt = null) : base(tagName, txt)
    {
    }

    public abstract A ToAnchor(string _href = null);
    
    
}