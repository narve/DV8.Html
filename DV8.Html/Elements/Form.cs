using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using DV8.Html.Utils;

// ReSharper disable InconsistentNaming

namespace DV8.Html.Elements;

public class Form : Linking//, ISelf
{
    public string BaseSelfUrl { get; set; }

    [Attr]
    public string Action { get; set; }

    [Attr]
    public HttpMethod Method { get; set; } = HttpMethod.Post;

    [Attr]
    public string Name { get; set; }

    public static Input Submit(object text = null)
        => new Input {InputType = "submit", Value = text?.ToString() ?? "Submit"};

    public Linking Disable(bool b = true)
    {
        Disabled = b;
        Subs.OfType<Input>().ForEach(s => s.Disable(b));
        //subs.Select(s => (s is INPUT) ? (s as INPUT).Disabled(b) : s).ToList();
        return this;
    }

    public override A ToAnchor(string baseRef = null)
    {
//            AssertThat($"shouldn't use ToAnchor on forms with method {Method} unless specifying _href",Method == HttpMethod.Get || !string.IsNullOrEmpty(_href));
//            AssertThat($"shouldn't use ToAnchor on forms unless SelfUrl is set, or specifying _href {GetHrefWithArgs(baseRef)}, {Name}",
//                !String.IsNullOrEmpty(baseRef) || !String.IsNullOrEmpty(BaseSelfUrl));
//            AssertThat($"shouldn't use ToAnchor on forms without base href", BaseHref, IsNotNull());
//            var href = _href ?? GetHrefWithArgs();
        return new A
        {
            rel = rel,
            Href = GetHrefWithArgs(baseRef?? BaseSelfUrl) ?? Action,
            // Text = Text ?? Name ?? Action ?? IANARels.EditForm,
            Disabled = Disabled, 
            Subs = Subs,
        };
    }

    private string GetHrefWithArgs(string baseHref)
        => UrlUtils.BuildQueryUrl(
            baseHref,
            BuildDict().SelectMany(kvp => kvp.Value.Select(s => new KeyValuePair<string, string>(kvp.Key, s))).ToList()
        );

    public Dictionary<string, List<string>> BuildDict()
    {
        var dict = new Dictionary<string, List<string>>();
        Subs?
            .OfTypeRecur<Input>()
            .Where(i => !string.IsNullOrEmpty(i.Name?.ToString()) && !string.IsNullOrEmpty(i.Value?.ToString()))
            .ForEach(i => dict[i.Name.ToString()] = new[] {i.Value.ToString()}.ToList());
        Subs?
            .OfTypeRecur<Select>()
            .Where(i => !string.IsNullOrEmpty(i.Name?.ToString()))
            .Select(s => new
            {
                name = s.Name,
                value = string.Join(",", s.Subs.OfTypeRecur<Option>().Where(o => o.Selected).Select(o => o.Value).ToArray())
            })
            .ForEach(i => dict[i.name.ToString()] = new[] {i.value.ToString()}.ToList());
        if (Disabled)
            dict[nameof(Disabled)] = new[] {"true"}.ToList();
        return dict;
    }

//        private string GetBaseHref() => BaseHref ?? GetBaseHref(Action, Method, rel); 
//
//        private static string GetBaseHref(string action, HttpMethod method, string rel)
//        {
//            if (method == HttpMethod.Get)
//            {
//                return action + "/form/" + Rel.Search;
//            }
//
//            if (method == HttpMethod.Post)
//            {
//                return action + "/form/" + rel;
//            }
//
//            throw new ArgumentException("Unsupported method: " + method);
//        }
//        public A SelfUrl => ToAnchor();
}