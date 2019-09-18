using System.Collections.Generic;
using System.Linq;

namespace DV8.Html.Elements
{
    public class Ul : HtmlElement
    {
        public Ul()
        {
        }

        public Ul(IEnumerable<IHtmlElement> subs)
        {
            Subs = subs.ToArray(); 
        }
    }
}