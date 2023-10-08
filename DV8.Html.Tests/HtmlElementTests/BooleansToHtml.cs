using DV8.Html.Elements;
using NUnit.Framework;

namespace DV8.Html.Tests.HtmlElementTests;

public class BooleansToHtml
{
    [Test]
    public void BooleanAttributesShouldNotBeIncludedIfFalse()
    {
        // Arrange
        var input = new Input
        {
            Disabled = false,
            Itemscope = false,
            Type = "text",
            
        };

        // Act
        var s = input.ToHtml();

        // Assert
        Assert.AreEqual("<input type='text'>", s.Canonical());
    }

    [Test]
    public void BooleanAttributesShouldUseAttributeNameAsValueNotBeIncludedIfTrue()
    {
        // Arrange
        var input = new Input {Disabled = true, Type="text"};

        // Act
        var s = input.ToHtml();

        // Assert
        Assert.AreEqual("<input disabled='disabled' type='text'>", s.Canonical());
    }
    
    [Test]
    public void Serializing_InputWithTrueBoolValues_ShouldWork()
    {
        // Arrange
        var input = new Option {Selected = true};

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