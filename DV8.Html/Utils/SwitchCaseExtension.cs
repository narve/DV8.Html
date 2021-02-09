using System;

namespace DV8.Html.Utils
{
    public static class SwitchCaseExtension
    {
        public static string UppercaseFirst(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsUpper(str[0]))
                return str;
            if (str.Length == 1)
                return str.ToUpper();
            return
                char.ToUpper(str[0]) + str.Substring(1);
        }
        public static string LowercaseFirst(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str[0]))
                return str;
            if (str.Length == 1)
                return str.ToLower();
            return
                char.ToLower(str[0]) + str.Substring(1);
        }
    }
}