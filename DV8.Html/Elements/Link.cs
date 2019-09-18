namespace DV8.Html.Elements
{
    public class Link
    {
        [Attr]
        public string Rel { get; set; }

        [Attr]
        public string Href { get; set; }

        [Attr]
        public string Type { get; set; }

        [Attr]
        public string As { get; set; }

        [Attr]
        public string Sizes { get; set; }

        [Attr]
        public string Media { get; set; }

        [Attr]
        public string CrossOrigin { get; set; }
    }
}