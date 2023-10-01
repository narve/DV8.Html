using System;

namespace DV8.Html.Tests.Serialization;

public class SamplePoco
{
    public string StringProp { get; set; }
        
    public bool BoolProp { get; set; }

    public DateTimeOffset? DateProp { get; set; }
}