using System;

namespace DV8.Html.Utils;

public static class Nulls
{
    public static T Require<T>(this T i, string msg)
    {
        if (i == null)
            throw new ArgumentException(msg);
        return i;
    }

    public static T OrElseThrow<T>(this T t, Func<string> msg)
    {
        if (t == null)
            throw new ArgumentException(msg());
        return t;
    }
}