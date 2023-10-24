using DV8.Html.Elements;
using NUnit.Framework;

namespace DV8.Html.Tests.HtmlElementTests;

public class InputSerializationTest
{
    [Test]
    public void InputShouldIncludeName()
    {
        var input = new Input {Name = "myName", Type = "text"};
        var s = input.ToHtml();
        Assert.AreEqual("<input name='myName' type='text'>", s.Canonical());
    }

}