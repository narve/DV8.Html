using System;

namespace DV8.Html.Elements;

public class A : Linking
{
    [Attr]
    public string Href { get; set; }

    public string Target { get; set; }

    public virtual Linking Disable(bool b = true)
    {
        Disabled = b;
        if (b)
        {
            Array.ForEach(Subs, s => s.Text += " [DISABLED]");
//                Subs.ForEach(s => s.Text += " [DISABLED]");
            Text += "[DISABLED]";
        }
        return this;
    }

    public override A ToAnchor(string hrefOverride = null)
    {
        return this;
    }

    public override string ToString()
    {
        if (Text == null) Text = "" + rel;
        return base.ToString();
    }

    public A()
    {
    }

    public A(string href, string text = null, string rel = null)
    {
        Href = href;
        Text = text ?? Href;
        this.rel = rel;
    }

    public A With(Action<A> mutator)
    {
        mutator(this);
        return this;
    }


    public A WithText(string text) => With(a => a.Text = text);

    public A WithClz(string clz) => With(a => a.Clz = clz);

    public A WithRel(string newRel) => With(a => a.rel = newRel);

    public A WithId(string newId) => With(a => a.Id = newId);

    public A WithTitle(string x) => With(a => a.Title = x);

    public A AddClz(string clz) => WithClz(Clz + " " + clz);

    public A AddRel(string newRel) => WithRel(rel + " " + newRel);

    public A WithHref(string s) => With(a => a.Href = s);
}