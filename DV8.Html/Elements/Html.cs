namespace DV8.Html.Elements;

public class Html : HtmlElement
{
    public override string ToHtml()
    {
        return "<!DOCTYPE html>" + base.ToHtml();
    }
}