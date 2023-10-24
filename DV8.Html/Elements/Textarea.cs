// ReSharper disable ArrangeAccessorOwnerBody

using DV8.Html.Framework;

namespace DV8.Html.Elements;

public class Textarea : InputElement, IFormElement
{
    protected override bool IsInlineBlock => true;

}