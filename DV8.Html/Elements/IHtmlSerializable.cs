using System.Collections.Generic;

namespace DV8.Html.Elements
{
    public interface IHtmlSerializable
    {
        IEnumerable<IHtmlElement> Serialize(int lvl, IHtmlSerializer fac);
    }
}