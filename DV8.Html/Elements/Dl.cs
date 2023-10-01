using System.Collections.Generic;
using System.Linq;

namespace DV8.Html.Elements;

public class Dl: HtmlElement
{
    public Dl()
    {
    }

    public Dl(IEnumerable<IHtmlElement> subs)
    {
        Subs.AddRange(subs);
    }
}