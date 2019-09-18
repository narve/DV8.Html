namespace DV8.Html.Elements
{
    public class Script: HtmlElement
    {
        [Attr]
        public string Src { get; set; }
//
//        [Attr]
//        public string Text { get; set; }

        [Attr]
        public string Type { get; set; }
    }
}