using System;
using System.Linq;

namespace DV8.Html.Utils;

public static class Enums
{
    public static T ParseEnum<T>(string s)
    {
        var t = typeof(T);
        var values = (T[]) Enum.GetValues(t);
        if (values == null)
        {
            throw new ArgumentException($"Ikke en enum-type: {t}");
        }
        if (values.All(v => v.ToString() != s))
        {
            throw new ArgumentException($"Ugyldig enum '{s}', gyldige verdier er: {values.ItemsToString()}");
        }
        return values.Single(v => v.ToString() == s);
    }

    public static string ToString(Type enumType, int? value) =>
        value == null ? null : Enum.GetName(enumType, value) ?? enumType.Name + "[" + value + "]";

    public static string ToIntList<T>(string arg) => arg.Split(',').Select(ParseEnum<T>).Cast<int>().ItemsToString();
}