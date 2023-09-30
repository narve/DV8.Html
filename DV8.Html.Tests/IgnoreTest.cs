using System.Linq;
using System.Text.Json.Serialization;
using DV8.Html.Serialization;
using NUnit.Framework;

namespace DV8.Html.Tests;

public class MyClass
{
    [JsonIgnore]
    public string MyIgnoredProperty { get; set; }
    public string MyIncludedProperty { get; set; }
}

public class IgnoreTest
{
    [Test]
    public void PropertyWithJsonIgnoreShouldBeIgnored()
    {
        var obj = new MyClass
        {
            MyIncludedProperty = "Hello, World!",
            MyIgnoredProperty = "Goodbye, World!",
        };
        var ser = HtmlSerializerRegistry.AddDefaults(new HtmlSerializerRegistry());
        var serialized = string.Join("", ser.Serialize(obj, 3).Select(x => x.ToHtml()).ToArray())
            .Replace("\r", "")
            .Replace("\n", "");

        var exp = @"
<dl itemscope='itemscope' itemtype='http://dv8.no/MyClass'>
<dt>Type</dt><dd title='http://dv8.no/MyClass'>MyClass</dd>
<dt>MyIncludedProperty</dt><dd itemprop='myIncludedProperty'><span>Hello, World!</span></dd>
</dl>"
            .Replace("\n", "")
            .Replace("\r", "");
        Assert.AreEqual(exp, serialized);
        
    }
}