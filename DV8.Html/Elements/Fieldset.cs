using System.Collections.Generic;
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

    public Fieldset(string legend, IEnumerable<IHtmlElement> subs = null)
    {
        Name = legend;
        Subs = (subs ?? new IHtmlElement[0]).With(new Legend(legend)).ToArray();
    }

}