using System.Collections.Generic;
using System.Linq;

namespace DV8.Html.Utils
{
    public static class OneAndOnlyExtension
    {
        public static T OneAndOnly<T>(this IEnumerable<T> enumerable,
            string msgTemplate = "Found {0} elements in a list of {1} with size {0} - expected exactly ONE. {2}", string prefix = "")
        {
            var list = enumerable.ToList();
            int count = list.Count;
            if (count != 1)
            {
                string elems = string.Join("; ", list.Take(5).ToArray());
                                throw new System.Exception(string.Format(prefix + msgTemplate, count, typeof(T).Name, elems));
//                string msgSuffix = $"Found {count} elements in a list of {typeof(T).Name} - expected exactly ONE. {elems}"; 
//                throw new System.Exception(msgTemplate??"" + msgSuffix);
            }
            return list.Single();
        }
    }
}