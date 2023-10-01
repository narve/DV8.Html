using DV8.Html.Support;

namespace DV8.Html.Elements;

public class Li : HtmlElement
{
    public Li()
    {
    }

    public Li(IHtmlElement sub) => Subs.Add(sub);

    public Li(string t) => AddIfNotEmpty(t);
}