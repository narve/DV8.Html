using System.Collections.Generic;
using System.Linq;

namespace DV8.Html.Elements
{
    public class Dl: HtmlElement
    {
        public Dl(IEnumerable<IHtmlElement> enumerable)
        {
            Subs = enumerable.ToArray();
        }
    }
}