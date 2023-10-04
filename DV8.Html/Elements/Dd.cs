using System.Collections.Generic;
using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Dd : HtmlElement
{
    public Dd()
    {
    }

    public Dd(string text) : base(null, text)
    {
    }

    public Dd(IEnumerable<IHtmlElement> subs) : base(subs)
    {
    }

    public Dd(params IHtmlElement[] subs) : base(subs)
    {
    }
}