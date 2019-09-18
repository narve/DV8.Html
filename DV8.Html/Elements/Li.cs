using DV8.Html.Support;

namespace DV8.Html.Elements
{
    public class Li : HtmlElement
    {
        public Li()
        {
        }

        public Li(IHtmlElement sub)
        {
            Subs = sub.ToArray();
        }
        public Li(string t)
        {
            Text = t;
        }
    }
}