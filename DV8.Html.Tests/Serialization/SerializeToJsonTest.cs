using DV8.Html.Accessors;
using DV8.Html.Elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace DV8.Html.Tests.Serialization;

public class SerializeToJsonTest
{
    [Test]
    public void SerializeOption()
    {
        var option = new Option(value: "option-value", "option description");
        var settings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
        };
        var json = JsonConvert.SerializeObject(option, settings);
        var exp = @"{'value':'option-value','text':'option description'}"
            .Replace("'", "\"");
        StringAssert.Contains("\"value\":\"option-value\"", json);
        StringAssert.Contains("\"text\":\"option description\"", json);

        // var deserializedOption = JsonConvert.DeserializeObject<Option>(json);
        // Assert.AreEqual("option-value", deserializedOption.Value);
        // Assert.AreEqual("option description", deserializedOption.GetTextContent());
    }
}