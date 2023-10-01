using DV8.Html.Elements;
using NUnit.Framework;

namespace DV8.Html.Tests.HtmlElementTests;

public class BasicElementTests
{
    [Test]
    public void Serializing_IncludesStyle()
    {
        // Arrange: 
        var th = new Th { Style = "display:none" };

        // Act
        var s = th.ToHtml();

        // Assert: 
        Assert.True(s.Contains("display:none"));
    }
}