using System.Collections.Generic;
using DV8.Html.Framework;
// ReSharper disable MemberCanBePrivate.Global

namespace DV8.Html.Elements;

public class Label : HtmlElement
{

    
    public string? For
    {
        get => Get("for");
        set => Set("for", value);
    }
    

    public Label()
    {
    }

    public Label(string txt) : base(null, txt)
    {
    }

    public Label(IEnumerable<IHtmlElement> htmlElements) : base(htmlElements)
    {
    }
    
    public Label(string txt, IEnumerable<IHtmlElement> htmlElements)
    {
        // We want to add the text first, not after the html elements
        AddIfNotEmpty(txt);
        Children.AddRange(htmlElements);
    }

    public static HtmlElement Wrap(string? v, IHtmlElement elem) =>
        new Label
        {
            Children = new List<IHtmlElement> { new Span(v + ": "), elem },
            Class = "label-for-" + elem.Id,
            For = elem.Id,
        };
}