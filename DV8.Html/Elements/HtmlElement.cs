using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

// ReSharper disable CollectionNeverUpdated.Global

// ReSharper disable ArrangeRedundantParentheses

namespace DV8.Html.Elements
{
    public class HtmlElement : IHtmlElement
    {
        [Attr] public string Id { get; set; }

        [Attr] public string Style { get; set; }

        [Attr] public string Title { get; set; }

        [Attr("class")] public string Clz { get; set; }

        [Attr] public bool Itemscope { get; set; }

        [Attr] public string Itemtype { get; set; }

        [Attr] public string Itemprop { get; set; }

        public string Tag { get; }

        public string Text { get; set; }

        public IDictionary<string, string> ExAttributes = new Dictionary<string, string>();


        public IHtmlElement[] Subs { get; set; } = new IHtmlElement[0];

        public HtmlElement()
        {
            Tag = GetTag();
        }

        public HtmlElement(string tagName, string txt = null)
        {
            Tag = tagName;
            Text = txt;
        }

        public string GetTag()
            => Tag?.ToLower() ?? GetType().Name.ToLower();

        public IHtmlElement[] ToArray() => new IHtmlElement[] {this};

        public virtual string ToHtml()
        {
            var writer = new StringWriter();
            writer.Write("<");
            writer.Write(GetTag());

            foreach (var pi in DefinedAttributes().Where(AttributeHasValue))
            {
                var val = pi.GetValue(this);
                var a = (Attr) pi.GetCustomAttribute(typeof(Attr));
                var attrName = a.name ?? pi.Name.ToLower();
                WriteAttribute(writer, attrName, val);
            }

            foreach (var (key, value) in ExAttributes ?? new Dictionary<string, string>())
            {
                WriteAttribute(writer, key, value);
            }

            writer.WriteLine(">");

            writer.Write(Text);
            foreach (var o in Subs ?? new IHtmlElement[0])
            {
                writer.WriteLine(o?.ToHtml() ?? "");
                writer.WriteLine();
            }

            foreach (var pi in GetType().GetProperties())
            {
                if (!Attribute.IsDefined(pi, typeof(Attr)) && !pi.Name.Equals(nameof(Subs)) &&
                    !pi.Name.Equals(nameof(Text)) &&
                    !pi.Name.Equals(nameof(Tag))
                )
                {
                    if (pi.GetValue(this) is HtmlElement val)
                        writer.WriteLine(val.ToHtml());
                }
            }

            writer.Write("</");
            writer.Write(GetTag());
            writer.WriteLine(">");
            return writer.ToString();
        }

        public void WriteAttribute(TextWriter writer, string attrName, object val)
        {
            writer.Write(" ");

            if (val is bool b && b)
            {
                writer.Write(attrName);
                writer.Write("='");
                writer.Write(attrName);
                writer.Write('\'');
            }
            else
            {
                writer.Write(attrName);
                writer.Write("='");
                writer.Write(val);
                writer.Write('\'');
            }
        }

        public bool AttributeHasValue(PropertyInfo pi) =>
            pi.GetValue(this) != null && (pi.PropertyType != typeof(bool) || (bool) pi.GetValue(this));

        public IEnumerable<PropertyInfo> DefinedAttributes() =>
            GetType().GetProperties().Where(pi => Attribute.IsDefined(pi, typeof(Attr)));

        public override string ToString() => Tag;

        public IEnumerable<IHtmlElement> Serialize(int lvl, IHtmlSerializer fac) => ToArray();
    }
}