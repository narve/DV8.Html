using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DV8.Html.Utils
{
    public static class Dicts
    {
        public static HashSet<T> ToHashSet<T>(
            this IEnumerable<T> source,
            IEqualityComparer<T> comparer = null)
        {
            return new HashSet<T>(source, comparer);
        }

        public static List<object> ToRawList(this IEnumerable e) => e.Cast<object>().ToList();

        /// <summary>
        /// Get a the value for a key. If the key does not exist, return the given defaultValue;
        /// </summary>
        /// <typeparam name="TK">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TV">The type of the values in the dictionary.</typeparam>
        /// <param name="dict">The dictionary to call this method on.</param>
        /// <param name="key">The key to look up.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The key value. null if this key is not in the dictionary.</returns>
        public static TV Get<TK, TV>(this IDictionary<TK, TV> dict, TK key, TV defaultValue = default(TV)) => 
            dict.TryGetValue(key, out var value) ? value : defaultValue;

//        public static TV Get<TK, TV>(this IDictionary<TK, TV> dict, TK key, Func<TV> defaultValue) => 
//            dict.TryGetValue(key, out var value) ? value : defaultValue();

//        public static TV Get<TK, TV>(this IDictionary<TK, TV> dict, TK key, Action thrower)
//        {
//            if(dict.TryGetValue(key, out var value)) return value;
//            thrower();
//            throw new ArgumentException("thrower didnt throw");
//        }

        public static bool HasValue(this Dictionary<string, List<string>> multiDict, string key) => 
            multiDict.HasNonNullValue(key) && multiDict[key].Any(s => !string.IsNullOrEmpty(s));

        public static bool HasNonNullValue<TK, TV>(this IDictionary<TK, TV> dict, TK key) => 
            dict.ContainsKey(key) && dict[key] != null;


    }
}