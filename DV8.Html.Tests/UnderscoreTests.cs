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
        var strings = new [] {"Apple", "Banana", "Cherry"};
        var html = 
            _<E.Html>(
                _<Head>(
                    _<Title>("Hello, World!")
                ),
                _<Body>(
                    _<H1>("Hello, World!"),
                    _<P>(
                        "This is a test."
                    ),
                    _<Ul>(
                        strings.Select(_<Li>)
                    )
                )
            );
        var act = html.ToHtml()
            .Replace("\r", "")
            .Replace("\n", "");
        var exp = @"<!DOCTYPE html><html><head><title>Hello, World!</title></head><body><h1>Hello, World!</h1><p>This is a test.</p><ul><li>Apple</li><li>Banana</li><li>Cherry</li></ul></body></html>";
        Assert.AreEqual(exp, act);
    }
}