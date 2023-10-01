using System.Collections.Generic;
using DV8.Html.Framework;

namespace DV8.Html.Serialization;

public interface IHtmlSerializer
{
    bool CanSerialize(object o);
    IEnumerable<IHtmlElement> Serialize(object o, int lvl, IHtmlSerializer fac);
}