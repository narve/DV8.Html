using System;
using DV8.Html.Elements;
using DV8.Html.Framework;

namespace DV8.Html.Mutators;

public static class Withers
{
    public static T With<T>(this T a, Action<T> mutator)
    {
        mutator(a);
        return a;
    }

    public static T WithClz<T>(this T e, string clz) where T : IHtmlElement
        => With(e, a => a.Clz = clz);

    public static A WithHref(this A t, string s) => With(t, a => a.Href = s);
    public static A WithRel(this A t, string newRel) => With(t, a => a.rel = newRel);
    public static A AddRel(this A t, string newRel) => WithRel(t, t.rel + " " + newRel);

    public static T WithId<T>(this T t, string newId) where T : IHtmlElement
        => With(t, a => a.Id = newId);

    public static T WithTitle<T>(this T t, string x) where T : IHtmlElement
        => With(t, a => a.Title = x);

    public static T AddClz<T>(this T t, string clz) where T : IHtmlElement
        => WithClz(t, t.Clz + " " + clz);
}