using System.Collections.Generic;
using System.Linq;

namespace DV8.Html.Elements;

public class Section : HtmlElement
{
    public Section()
    {
    }

    public Section(IEnumerable<IHtmlElement> subs) : base(subs)
    {
    }
    public Section(params IHtmlElement[]subs): base(subs)
    {
    }
}