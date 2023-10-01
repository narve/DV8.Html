using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class A : Linking
{
    [Attr]
    public string Href { get; set; }

    public string Target { get; set; }

    public A()
    {
    }

    public A(string href, string text = null, string rel = null): base(null, text)
    {
        Href = href;
        this.rel = rel;
    }

    
    public virtual Linking Disable(bool b = true)
    {
        Disabled = b;
        // if (b)
        // {
            // Subs.ForEach(s => s.Text += " [DISABLED]");
//                Subs.ForEach(s => s.Text += " [DISABLED]");
            // Text += "[DISABLED]";
        // }
        return this;
    }

    public override A ToAnchor(string hrefOverride = null) => this;

    /// <summary>
    /// This method returns the HTML representation of the element, as as ToHtml
    /// </summary>
    /// <returns></returns>
    public override string ToString() => ToHtml();

}