using System.Collections.Generic;
using DV8.Html.Framework;
// ReSharper disable UnusedType.Global

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