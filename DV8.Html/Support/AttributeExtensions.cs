using DV8.Html.Framework;

namespace DV8.Html.Support;

public static class AttributeExtensions
{

    public static T WithClz<T>(this T t, string clz) where T : IHtmlElement
    {
        t.Clz = string.IsNullOrEmpty(t.Clz) ? clz : (t.Clz + " " + clz);
        return t;
    }
}