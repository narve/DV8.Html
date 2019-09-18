using System;

namespace DV8.Html.Utils
{
    public static class SwitchCaseExtension
    {
        public static string UppercaseFirst(this string str)
        {
            if (String.IsNullOrEmpty(str) || Char.IsUpper(str[0]))
                return str;
            if (str.Length == 1)
                return str.ToUpper();
            return
                Char.ToUpper(str[0]) + str.Substring(1);
        }
        public static string LowercaseFirst(this string str)
        {
            if (String.IsNullOrEmpty(str) || Char.IsLower(str[0]))
                return str;
            if (str.Length == 1)
                return str.ToLower();
            return
                Char.ToLower(str[0]) + str.Substring(1);
        }
    }
}