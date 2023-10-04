using System;
using System.Collections.Generic;

namespace DV8.Html.Utils;

public static class DictionaryExtensions
{
    public static TValue GetOr<TKey, TValue>
    (this IDictionary<TKey, TValue> dictionary,
        TKey key,
        TValue defaultValue)
    {
        TValue value;
        return dictionary.TryGetValue(key, out value) ? value : defaultValue;
    }

    public static TValue GetOr<TKey, TValue>
    (this IDictionary<TKey, TValue> dictionary,
        TKey key,
        Func<TValue> defaultValueProvider)
    {
        TValue value;
        return dictionary.TryGetValue(key, out value) ? value
            : defaultValueProvider();
    }
}