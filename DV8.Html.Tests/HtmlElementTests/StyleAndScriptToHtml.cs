using DV8.Html.Elements;
using NUnit.Framework;

namespace DV8.Html.Tests.HtmlElementTests;

public class StyleAndScriptToHtml
{
    [Test]
    public void StyleShouldBeRendered()
    {
        var element = new Style("body { background-color: red; content: 'test<a>'}")
        {
            Media = "screen"
        };
        var html = element.ToHtml().Canonical();
        Assert.AreEqual("<style media='screen'>body { background-color: red; content: 'test<a>'}</style>", html);
    }
    [Test]
    public void ScriptShouldBeRendered()
    {
        var element = new Script("hack('<&>')")
        {
            Type = "text/javascript"
        };
        var html = element.ToHtml().Canonical();
        Assert.AreEqual("<script type='text/javascript'>hack('<&>')</script>", html);
    }
    
}