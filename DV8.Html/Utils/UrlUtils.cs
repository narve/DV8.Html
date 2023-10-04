using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.String;

namespace DV8.Html.Utils;

public static class UrlUtils {
    public static string? BuildQueryUrl(string? baseRef, IEnumerable<KeyValuePair<string, string>> dict)
    {
        var l = dict.ToList();
        return l.Any()
            ? baseRef + "?" + Join("&", l.Select(kvp => kvp.Key + "=" + EncodeUrlString(kvp.Value)).ToArray())
            : baseRef;
    }

    public static string EncodeUrlString(object? val)
    {
        if (val == null)
        {
            return "";
        }
        else if (val is System.Collections.IList)
        {
            throw new ArgumentException("EncodeURL => val is list, should not  happen?!");
//                return ((System.Collections.IEnumerable) val).ToRawList().ItemsToString();
        }
        else
        {
            return HttpUtility.UrlEncode(val.ToString())!;
        }
    }
}