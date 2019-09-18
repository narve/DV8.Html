using System;

namespace DV8.Html.Elements
{
    public class Attr : Attribute
    {
        public string name;

        public Attr()
        {
        }

        public Attr(string name)
        {
            this.name = name;
        }
    }
}