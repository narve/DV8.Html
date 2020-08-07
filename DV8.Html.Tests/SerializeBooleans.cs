using System.Linq;
using DV8.Html.Elements;
using DV8.Html.Serialization;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace DV8.Html.Tests
{
    public class SerializeBooleans
    {
        [Test]
        public void Serializing_InputWithTrueBoolValues_ShouldWork()
        {
            // Arrange
            var input = new Option {Selected = true};

            // Act
            var s = input.ToHtml();

            // Assert
            StringAssert.Contains( "selected='selected'", s);
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
}