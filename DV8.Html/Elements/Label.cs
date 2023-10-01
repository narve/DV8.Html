using System.Collections.Generic;

namespace DV8.Html.Elements;

public class Label : HtmlElement
{
    public Label()
    {
    }

    public Label(string txt) => AddIfNotEmpty(txt); 

    [Attr]
    public string For { get; set; }

    public static HtmlElement Wrap(string v, IHtmlElement elem) =>
        new Label
        {
            Subs = new List<IHtmlElement> { new Span(v + ": "), elem },
            Clz = "label-for-" + elem.Id,
            For = elem.Id,
        };
}