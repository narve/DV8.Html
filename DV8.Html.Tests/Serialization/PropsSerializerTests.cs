using System;
using System.Collections.Generic;
using System.Linq;
using DV8.Html.Accessors;
using DV8.Html.Elements;
using DV8.Html.Serialization;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace DV8.Html.Tests.Serialization;

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
            StringProp = "stringValue",
        }, 3, ser).ToArray();

        // Assert

        var xml = string.Join("", elements.Select(e => e.ToHtml()));
        var exp = @"
<dl itemscope=""itemscope"" itemtype=""http://dv8.no/SamplePoco"">  
<dt>Type</dt>  <dd title=""http://dv8.no/SamplePoco"">SamplePoco</dd>  
<dt>BoolProp</dt>  <dd itemprop=""boolProp"">    <span>False</span>  </dd>  
<dt>StringProp</dt>  <dd itemprop=""stringProp"">    <span>stringValue</span>  </dd>
</dl>
";
        AreEqual(exp.Canonical(), xml.Canonical());

        AreEqual(1, elements.Length);
        var subs = elements.Single().Children;
        var dt = subs[0];
        var dd = subs[1];
        AreEqual("Type", dt.GetTextContent());
        AreEqual("SamplePoco", dd.GetTextContent());
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
        AreEqual("li", elements[0].Children[0].Tag);
        AreEqual("dl", elements[0].Children[0].Children[0].Tag);
    }

    [Test]
    public void Serialize_DateTime()
    {
        var ser = HtmlSerializerRegistry.AddDefaults(new HtmlSerializerRegistry());
        var toSer = new DateTimeOffset(2023, 10, 1, 10, 0, 0, TimeSpan.FromHours(2));
        var element = ser.Serialize(toSer, 3, ser).Single();
        var time = (Time)element;
        var exp = "2023-10-01T10:00:00+02:00";
        AreEqual(exp, time.GetTextContent());
        AreEqual(exp, time.Datetime);
    }

    [Test]
    public void Serialize_Dict_With_Nulls()
    {
        var ser = new HtmlSerializerRegistry();
        ser.Add(o => o is IDictionary<string, object>, o =>
        {
            // try
            {
                return new GenDictSerializer().Serialize(o, 3, ser);
            }
            // catch (Exception e)
            // {
            // return new Span("ERROR").ToArray();
            // }
        });
        HtmlSerializerRegistry.AddDefaults(ser);
        ser.Serialize(null, 3, ser);


        IDictionary<string, object> toSer = new Dictionary<string, object>
        {
            { "key1", "val1" },
            { "key2", null },
            {
                "key3", new Dictionary<string, object>
                {
                    { "key4", null }
                }
            }
        };

        var elements = ser.Serialize(toSer, 3, ser);
    }
}