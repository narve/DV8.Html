namespace DV8.Html.Elements
{
    public interface IHtmlElement : IHtmlSerializable
    {
        [Attr]
        string Id { get; set; }

        [Attr]
        string Style { get; set; }

        [Attr("class")]
        string Clz { get; set; }

        string Text { get; set; }

        string ToHtml();
        IHtmlElement[] Subs { get; set; }

        string Tag { get; }

        string Title { get; set; }
    }
}