using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DV8.Html.Utils
{
    public static class ItemsToStringExtension
    {
        public static string DictToString<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> items, string format = "{0}='{1}' ")
        {
            return items
                .Aggregate(new StringBuilder("{"), (sb, kvp) => sb.AppendFormat(format, kvp.Key, kvp.Value))
                .Append('}')
                .ToString();
        }
        public static string ItemsToString<T>(this IEnumerable<T> items, string sep = ", ", string format = "{0}")
        {
            return String.Format(format, String.Join(sep, items.ToArray()));
        }
    }

}