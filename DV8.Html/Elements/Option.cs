namespace DV8.Html.Elements
{
    public class Option : HtmlElement
    {
        [Attr]
        public object Value { get; set; }

        [Attr]
        public bool Selected { get; set; }

        [Attr]
        public bool Disabled { get; set; }

        public string Name { get; set; }

        [Attr]
        public string Tooltip{ get; set; }

        public Option()
        {
        }

        public Option(string value, string disp = null)
        {
            Name = value;
            Value = value;
            Text = disp??value; 
        }
    }
}