using System;

namespace DV8.Html.Framework;

public class Attr : Attribute
{
    public string? Name { get; set; }

    public Attr()
    {
    }

    public Attr(string name)
    {
        Name = name;
    }
}