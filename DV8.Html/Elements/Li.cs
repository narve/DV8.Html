using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Li : HtmlElement
{
    public Li()
    {
    }

    public Li(IHtmlElement sub) => Children.Add(sub);

    public Li(string t) : base(null, t)
    {
    }
}