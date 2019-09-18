using System;

namespace DV8.Html.Support
{
    [AttributeUsage(AttributeTargets.All)]
    public class RelAttribute : Attribute
    {
        public readonly string Rel;

        public RelAttribute(string rel)
        {
            Rel = rel;
        }
    }
}