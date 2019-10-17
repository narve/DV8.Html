using System.Linq;
using DV8.Html.Serialization;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace DV8.Html.Tests
{
    public class PropsSerializerTests
    {
        [Test]
        public void Serializing_WithIncludeType_ShouldIncludeType()
        {
            // Arrange
            var ser = HtmlSerializerRegistry.AddDefaults(new HtmlSerializerRegistry());

            // Act
            var elements = ser.Serialize(new SamplePoco
            {
                StringProp = "stringval",
            }, 3, ser).ToArray();

            // Assert
            AreEqual(1, elements.Length);
            AreEqual("SamplePoco", elements[0].Subs[1].Text);
        }

        [Test]
        public void Serializing_Array_ShouldBeUlWithLiWithDl()
        {
            // Arrange
            var ser = HtmlSerializerRegistry.AddDefaults(new HtmlSerializerRegistry());

            // Act
            var elements = ser.Serialize(new[]
            {
                new SamplePoco
                {
                    StringProp = "stringval",
                }
            }, 3, ser).ToArray();

            // Assert
            AreEqual("ul", elements[0].Tag);
            AreEqual("li", elements[0].Subs[0].Tag);
            AreEqual("dl", elements[0].Subs[0].Subs[0].Tag);
        }
    }
}