using System;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class A : Linking
{
    [Attr]
    public string? Href 
    {
        get => Get("href");
        set => Set("href", value);
    }
    

    public string? Target 
    {
        get => Get("target");
        set => Set("target", value);
    }
    

    public A()
    {
    }

    public A(string href, string? text = null, string? rel = null): base(null, text)
    {
        Href = href ?? throw new ArgumentNullException(nameof(href));
        this.Rel = rel;
    }



    public override A ToAnchor(string? hrefOverride = null) => this;

    /// <summary>
    /// This method returns the HTML representation of the element, as as ToHtml
    /// </summary>
    /// <returns></returns>
    public override string ToString() => ToHtml();

}