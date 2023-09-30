using System;
using System.Collections.Generic;
using System.Linq;

namespace DV8.Html.Utils;

public static class IANARels
{
    public const string SearchFormSuffix = "-search";
    public const string CreateFormSuffix = "-create";
    public const string UpdateFormSuffix = "-edit";
    public const string ProcessSuffix = "-process";
    public const string Form = "form";
    public const string FormSuffix = "-" + Form;

    public const string Self = "self";
    public const string Prev = "prev";
    public const string Next = "next";
    public const string Edit = "edit";
    public const string EditForm = Edit + FormSuffix;
    public const string Create = "create";
    public const string Delete = "delete";

    public static readonly IReadOnlyCollection<string> All;

    static IANARels()
    {
        All = Array.AsReadOnly(
            typeof(IANARels).GetFields()
                .Where(fi => fi.FieldType == typeof(string))
                .Select(fi => fi.GetValue(null).ToString())
                .Where(s => !s.StartsWith("-"))
                //                    .Where(s => !s.Contains("Suffix"))
                .ToArray()
        );
    }


}