using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using DV8.Html.Elements;

namespace DV8.Html.Utils
{
    public static class ForEachExtension
    {

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();
            foreach (var element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static T SingleOr<T>(this IEnumerable<T> source, T orElse)
        {
            var t = source.FirstOrDefault();
            return t == null ? orElse : t;
        }

        public static T SingleOr<T>(this IEnumerable<T> source, Func<T> orElse)
        {
            var t = source.FirstOrDefault();
            return t == null ? orElse() : t;
        }

        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var element in source)
                action(element);
            return source;
        }

        public static IEnumerable<T> With<T>(this IEnumerable<T> source, T toAdd)
        {
            var list = source.ToList();
            list.Add(toAdd);
            return list;
        }

        public static IEnumerable<T> PossiblyWith<T>(this IEnumerable<T> source, T toAdd) =>
            toAdd == null ? source : With(source, toAdd);

        public static IEnumerable<T> OfTypeRecur<T>(this IEnumerable<IHtmlElement> ea) where T : IHtmlElement =>
            ea.SelectMany(e => e is T ? new[] {(T) e} : OfTypeRecur<T>(e.Subs)).ToArray();
    }
}