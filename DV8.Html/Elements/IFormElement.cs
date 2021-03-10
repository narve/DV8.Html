namespace DV8.Html.Elements
{
    public interface IFormElement: IHtmlElement
    {
        [Attr]
        bool Disabled { get; set; }

        [Attr]
        string Name { get; set; }

        // object Value { get; set; }

        [Attr]
        bool Required { get; set; }
    }
}