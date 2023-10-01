﻿using System.Collections.Generic;
using System.Linq;
using DV8.Html.Utils;

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
            Subs.AddRange(subs);
        else if(!string.IsNullOrEmpty(legend))
            Subs.Add(new Legend(legend));
    }

}