﻿namespace DV8.Html.Elements
{
    public class Label : HtmlElement
    {
        [Attr]
        public string For { get; set; }

        public static HtmlElement Wrap(string v, IHtmlElement elem)
        {
            return new Label
            {
                Subs = new[] {new Span(v + ": "), elem},
                Clz = "label-for-" + elem.Id,
                For = elem.Id,
            };
        }
    }
}