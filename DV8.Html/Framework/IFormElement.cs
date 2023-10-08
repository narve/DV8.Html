namespace DV8.Html.Framework;

public interface IFormElement: IHtmlElement
{
    
    bool Disabled { get; set; }

    
    string? Name { get; set; }

    // object Value { get; set; }

    
    bool Required { get; set; }
}