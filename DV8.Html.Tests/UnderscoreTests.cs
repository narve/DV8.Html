using System.Linq;
using DV8.Html.Elements;
using NUnit.Framework;
using E = DV8.Html.Elements;
using static DV8.Html.Prefixes.Underscore;

namespace DV8.Html.Tests;

public class UnderscoreTests
{
    [Test]
    public void TestIt()
    {
        var fruits = new[] { "Apple", "Banana", "Cherry" };
        var html =
            _<E.Html>(
                _<Head>(
                    _<Title>("Hello, World!")
                ),
                _<Body>(
                    _<H1>("Hello, World!"),
                    _<P>(
                        _("This is a paragraph with <>. "), // Becomes plain text, not an element. Text is escaped. 
                        _<Ul>(
                            fruits.Select(_<Li>)
                        )
                    ),
                    _UNSAFE("This will <em>not</em> be escaped") // Allows any HTML, don't use this with untrusted content. 
                )
            );
        var act = html.ToHtml();
        var exp = @"
<!DOCTYPE html><html>
<head><title>Hello, World!</title></head>
<body><h1>Hello, World!</h1><p>This is a paragraph with &lt;&gt;. <ul><li>Apple</li><li>Banana</li><li>Cherry</li></ul></p>
This will <em>not</em> be escaped
</body></html>";
        
        Assert.AreEqual(exp.StringLineBreaks(), act.StringLineBreaks());
    }
}