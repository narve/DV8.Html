using DV8.Html.Elements;
using NUnit.Framework;

namespace DV8.Html.Tests.HtmlElementTests;

public class BooleansToHtml
{
    [Test]
    public void BooleanAttributesShouldNotBeIncludedIfFalse()
    {
        // Arrange
        var input = new Input {Disabled = false};

        // Act
        var s = input.ToHtml();

        // Assert
        Assert.AreEqual("<input type='text'>", s.Canonical());
        StringAssert.DoesNotContain( "disabled", s);
    }

    [Test]
    public void BooleanAttributesShouldUseAttributeNameAsValueNotBeIncludedIfTrue()
    {
        // Arrange
        var input = new Input {Disabled = true};

        // Act
        var s = input.ToHtml();

        // Assert
        Assert.AreEqual("<input disabled='disabled' type='text'>", s.Canonical());
    }
    
    [Test]
    public void Serializing_InputWithTrueBoolValues_ShouldWork()
    {
        // Arrange
        Option input = new Option {Selected = true};

        // Act
        var s = input.ToHtml();

        // Assert
        StringAssert.Contains( "selected='selected'", s.Canonical());
    }
        
    [Test]
    public void Serializing_InputWithFalseBoolValues_ShouldWork()
    {
        // Arrange
        var input = new Option {Selected = false};

        // Act
        var s = input.ToHtml();

        // Assert
        StringAssert.DoesNotContain( "selected", s);
    }
}