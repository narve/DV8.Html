using System.Collections.Generic;

namespace DV8.Html.Framework;

public abstract class InputElement: HtmlElement
{
     public bool Disabled 
    {
        get => GetBool("disabled");
        set => SetBool("disabled", value);
    }        

    
    public string? Name
    {
        get => Get("name");
        set => Set("name", value);
    }
    
     public bool Required
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