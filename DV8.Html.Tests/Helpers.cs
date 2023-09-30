namespace DV8.Html.Tests;

public static class Helpers
{
    public static string StringLineBreaks(this string s) =>
        s.Replace("\r", "").Replace("\n", "");
}