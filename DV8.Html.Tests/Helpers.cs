using System.Text.RegularExpressions;

namespace DV8.Html.Tests;

public static class Helpers
{
    public static string Canonical(this string s)
    {
        // Replace all attributes with a single quoted attribute:  
        // <div class="foo" bar="baz"> -> <div class='foo' bar='baz'>
        // var match = attrExp.Match(s);
        var attrPattern = "=\"([^\"]*)\"";
        s = Regex.Replace(s, attrPattern, "='$1'");
 
        // Replace indents: 
        var indentPattern = ">(\\s+)<";
        s = Regex.Replace(s, indentPattern, "><");
        
        return s.Replace("\r", "")
            .Replace("\n", "");
    }
}