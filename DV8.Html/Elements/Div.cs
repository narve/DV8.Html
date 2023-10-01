using System.Collections.Generic;
using System.Linq;

namespace DV8.Html.Elements;

public class Div : HtmlElement
{
    public Div()
    {
    }

    public Div(IEnumerable<IHtmlElement> subs)
    {
        Subs.AddRange(subs);
    }
    public Div(params IHtmlElement[]subs)
    {
        Subs.AddRange(subs);
    }
}