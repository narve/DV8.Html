

// ReSharper disable InconsistentNaming

using DV8.Html.Elements;

namespace DV8.Html.Framework;

public abstract class Linking : HtmlElement
{
    
    public string? Rel
    {
        get => Get("rel");
        set => Set("rel", value);
    }
        
    protected Linking()
    {
    }

    protected Linking(string? tagName = null, string? txt = null) : base(tagName, txt)
    {
    }

    public abstract A ToAnchor(string? href = null);
    
    
}