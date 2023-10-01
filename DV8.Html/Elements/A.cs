using System;
using DV8.Html.Mutators;

namespace DV8.Html.Elements;

public class A : Linking
{
    [Attr]
    public string Href { get; set; }

    public string Target { get; set; }

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

    public override A ToAnchor(string hrefOverride = null)
    {
        return this;
    }

    public override string ToString()
    {
        // if (Text == null) Text = "" + rel;
        // return base.ToString();
        var s = (IHtmlSerializable)this;
        return s.ToHtml();
    }

    public A()
    {
    }

    public A(string href, string text = null, string rel = null)
    {
        Href = href;
        this.rel = rel;
        AddIfNotEmpty(text ?? href);
    }

}