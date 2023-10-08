using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Script : HtmlElement
{
    
    public string? Src 
    {
        get => Get("src");
        set => Set("src", value);
    }
        
//
//        
//        public string Text { get; set; }

    
    public string? Type 
    {
        get => Get("type");
        set => Set("type", value);
    }
    

    public Script()
    {
    }

    /// NB this constructor does not escape unsafe content
    public Script(string txt)
    {
        if (!string.IsNullOrEmpty(txt))
            Children.Add(new UnsafeTextContent(txt));
    }
}