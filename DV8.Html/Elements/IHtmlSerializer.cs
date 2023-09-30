using System.Collections.Generic;

namespace DV8.Html.Elements;

public interface IHtmlSerializer
{
    bool CanSerialize(object o);
    IEnumerable<IHtmlElement> Serialize(object o, int lvl, IHtmlSerializer fac);
}