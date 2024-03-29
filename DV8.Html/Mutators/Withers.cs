using System;
using System.Net.Http;
using DV8.Html.Elements;
using DV8.Html.Framework;
// ReSharper disable UnusedMember.Global

namespace DV8.Html.Mutators;

public static class Withers
{
    public static T With<T>(this T a, Action<T> mutator)
    {
        mutator(a);
        return a;
    }

    public static T WithAttribute<T>(this T e, string attributeName, string attributeValue) where T : IHtmlElement =>
        With(e, element => element.Attributes[attributeName] = attributeValue);

    public static T WithClass<T>(this T e, string? clz) where T : IHtmlElement
        => With(e, a => a.Class = clz);

    public static T WithName<T>(this T e, string? name) where T: IFormElement
        => With(e, a => a.Name = name);
    
    public static Form WithMethod(this Form e, HttpMethod method)  
        => With(e, a => a.Method = method.ToString());
    
    public static A WithHref(this A t, string s) => With(t, a => a.Href = s);
    public static A WithRel(this A t, string newRel) => With(t, a => a.Rel = newRel);
    public static A AddRel(this A t, string newRel) => WithRel(t, t.Rel + " " + newRel);

    public static Td WithColspan(this Td t, int colspan)
        => With(t, element => element.Colspan = colspan);

    public static Th WithColspan(this Th t, int colspan)
        => With(t, element => element.Colspan = colspan);

    public static T WithId<T>(this T t, string newId) where T : IHtmlElement
        => With(t, a => a.Id = newId);

    public static T WithTitle<T>(this T t, string? x) where T : IHtmlElement
        => With(t, a => a.Title = x);

    public static T AddClass<T>(this T t, string clz) where T : IHtmlElement
        => WithClass(t, t.Class + " " + clz);
}