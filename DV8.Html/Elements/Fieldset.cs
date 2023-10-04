using System.Collections.Generic;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Fieldset : HtmlElement
{
    [Attr]
    public string Name { get; set; }
        
    public Fieldset()
    {
    }

    public Fieldset(string legend = null, IEnumerable<IHtmlElement> subs = null)
    {
        Name = legend;
        if(subs!=null)
            Children.AddRange(subs);
        else if(!string.IsNullOrEmpty(legend))
            Children.Add(new Legend(legend));
    }

}