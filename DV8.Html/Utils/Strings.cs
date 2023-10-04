using System.Text.RegularExpressions;
using static System.String;

namespace DV8.Html.Utils;

public static class Strings
{
    public static string LimitLength(this string s, int m)
        => s == null || s.Length <= m
            ? s
            : s.Substring(0, m);

    public static string EmptyAsNull(this string s)
        => IsNullOrEmpty(s) ? null : s;

    public static string IfNullOrEmptyThen(this string s, string other)
        => IsNullOrEmpty(s) ? other : s;

    public static string StripRightSide(this string s, int charsToStrip)
        => s.Substring(0, s.Length - charsToStrip);

    public static string StripMargin(this string s) 
        => Regex.Replace(s, @"[\t ]+\|", Empty);

    public static string StripLineBreaks(this string s) 
        => Regex.Replace(s, @"\r\n", Empty);
}