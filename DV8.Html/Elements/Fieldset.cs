using System.Collections.Generic;
using DV8.Html.Framework;
// ReSharper disable UnusedMember.Global

namespace DV8.Html.Elements;

public class Fieldset : HtmlElement
{
    [Attr]
    public string? Name 
    {
        get => Get("name");
        set => Set("name", value);
    }
    
    public Fieldset()
    {
    }

    public Fieldset(string? legend = null, IEnumerable<IHtmlElement>? children = null)
    {
        Name = legend;
        if(children!=null)
            Children.AddRange(children);
        else if(!string.IsNullOrEmpty(legend))
            Children.Add(new Legend(legend));
    }

}