namespace DV8.Html.Utils;

public static class Numbers
{
    public static int? IntOrNull(this string s)
    {
        int? toReturn = null;
        if (int.TryParse(s, out var someInt))
        {
            toReturn = someInt;
        }
        return toReturn;
    }
    public static long? LongOrNull(this string s)
    {
        long? toReturn = null;
        if (long.TryParse(s, out var someInt))
        {
            toReturn = someInt;
        }
        return toReturn;
    }
}