using System.Collections.Generic;

namespace DV8.Html.Framework;

public abstract class InputElement: HtmlElement
{
    [Attr] public bool Disabled 
    {
        get => GetBool("disabled");
        set => SetBool("disabled", value);
    }        

    [Attr]
    public string? Name
    {
        get => Get("id");
        set => Set("id", value);
    }
    
    [Attr] public bool Required
    {
        get => GetBool("required");
        set => SetBool("required", value);
    }            

    
    protected InputElement(IEnumerable<IHtmlElement> htmlElements): base(htmlElements)
    {
    }

    protected InputElement(string? tagName = null, string? text = null): base(tagName, text)
    {
    }
}