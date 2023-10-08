using System.Collections.Generic;
using System.Linq;
using DV8.Html.Framework;
using DV8.Html.Utils;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable ClassNeverInstantiated.Global

// ReSharper disable InconsistentNaming

namespace DV8.Html.Elements;

public class Form : Linking//, ISelf
{
    public string? BaseSelfUrl { get; set; }

    
    public string? Action 
    {
        get => Get("action");
        set => Set("action", value);
    }
        

    
    public string? Method
    {
        get => Get("method");
        set => Set("method", value);
    }
        

    
    public string? Name
    {
        get => Get("name");
        set => Set("name", value);
    }
    

    public static Input Submit(object? text = null) => new()
    {
        Type = "submit", 
        Value = text?.ToString() ?? "Submit"
    };

    // public Linking Disable(bool b = true)
    // {
    //     Disabled = b;
    //     Children.OfType<Input>().ForEach(s => s.Disable(b));
    //     //subs.Select(s => (s is INPUT) ? (s as INPUT).Disabled(b) : s).ToList();
    //     return this;
    // }

    public override A ToAnchor(string? baseRef = null) =>
        new()
        {
            Rel = Rel,
            Href = GetHrefWithArgs(baseRef?? BaseSelfUrl) ?? Action,
            // Text = Text ?? Name ?? Action ?? IANARels.EditForm,
            // Disabled = Disabled, 
            Children = Children,
        };

    private string? GetHrefWithArgs(string? baseHref)
        => UrlUtils.BuildQueryUrl(
            baseHref,
            BuildDict().SelectMany(kvp => kvp.Value.Select(s => new KeyValuePair<string, string>(kvp.Key, s))).ToList()
        );

    public Dictionary<string, List<string>> BuildDict()
    {
        var dict = new Dictionary<string, List<string>>();
        Children
            .OfTypeRecur<Input>()
            .Where(i => !string.IsNullOrEmpty(i.Name?.ToString()) && !string.IsNullOrEmpty(i.Value?.ToString()))
            .ForEach(i => dict[i.Name!.ToString()] = new[] {i.Value!.ToString()}.ToList());
        Children
            .OfTypeRecur<Select>()
            .Where(i => !string.IsNullOrEmpty(i.Name?.ToString()))
            .Select(s => new
            {
                name = s.Name,
                value = string.Join(",", s.Children.OfTypeRecur<Option>().Where(o => o.Selected).Select(o => o.Value).ToArray())
            })
            .ForEach(i => dict[i.name!.ToString()] = new[] {i.value.ToString()}.ToList());
        // if (Disabled)
        //     dict[nameof(Disabled)] = new[] {"true"}.ToList();
        return dict;
    }

}