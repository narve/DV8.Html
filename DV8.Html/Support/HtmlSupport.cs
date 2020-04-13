using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DV8.Html.Elements;
using DV8.Html.Utils;
using Newtonsoft.Json;

// ReSharper disable PossibleNullReferenceException

// ReSharper disable CanBeReplacedWithTryCastAndCheckForNull

namespace DV8.Html.Support
{
    public static class HtmlSupport
    {
        public static IHtmlElement Labelize(this IHtmlElement element, string label = null)
        {
            return Label.Wrap(label ?? (element as IFormElement)?.Name, element);
        }

        public static IHtmlElement[] ToArray(this IHtmlElement element)
        {
            return new[] {element};
        }

//        public static string ToString(object x)
//        {
//            if (x == null)
//                return "NULL";
//            Type theType = x.GetType();
//            if (x is string)
//            {
//                return (string) x;
//            }
//            else if (x is Form)
//            {
//                return ((Form) x).Name;
//            }
//            else if (x is IList<Prop<ProcInst>>)
//            {
//                return $"Properties[{((IEnumerable) x).Count()}]";
//            }
//            else if (x is IList<Prop<ActivityAction>>)
//            {
//                return $"Properties[{((IEnumerable) x).Count()}]";
//            }
//            else if (x is IDictionary && x.GetType().GetGenericArguments().Length > 1)
//            {
//                string t1 = TypeName(theType.GetGenericArguments()[0]),
//                    t2 = TypeName(theType.GetGenericArguments()[1]);
//                int c = ((IEnumerable) x).Count();
//                return $"Map of ({t1}, {t2}) [{c} items]";
//            }
//            else if (x is IEnumerable && theType.GetGenericArguments().Length > 0)
//            {
//                string t1 = TypeName(theType.GetGenericArguments()[0]);
//                int c = ((IEnumerable) x).Count();
//                return $"List of {t1} [{c} items]";
//            }
//            else if (x is IEnumerable)
//            {
//                int c = ((IEnumerable) x).Count();
//                const string tname = "Collection";
//                return $"{tname}[{c}]";
//            }
//            else
//            {
//                return x.ToString();
//            }
//        }

//        private static string TypeName(Type theType)
//        {
//            var tname = theType.Name;
//            if (tname.Contains('`')) tname = tname.Substring(0, tname.IndexOf('`'));
//            return tname;
//        }

        //        public static IEnumerable<A> GetLinksFromContextOrCreateAndCache(object po)
        //        {
        //            if (HttpContext.Current != null && HttpContext.Current.Items.Contains("Link") && HttpContext.Current.Items["Link"] != null)
        //            {
        //                var links = (List<A>) HttpContext.Current.Items["Link"];
        //                Log.Debug("Cached links: " + links.Count);
        //                return links;
        //            }
        //            else
        //            {
        //                var links = GetLinks(po);
        ////                Log.Debug("Previously un-cached links for " + po + ": " + links.ItemsToString());
        //                if (HttpContext.Current != null)
        //                {
        //                    HttpContext.Current.Items["Link"] = links;
        //                }
        //                return links;
        //            }
        //        }
        //
        //        public static List<A> GetLinks(object po)
        //        {
        //            var l = new List<A>();
        //            if (po is IWebActions)
        //                l.AddRange(((IWebActions) po).ListActions.OfType<A>());
        //            //l.AddRange(Forms(uri, po).Select(f => ToAnchor(uri, f)));
        //
        //            if (po is ISelf)
        //            {
        //                l.Add((po as ISelf).SelfUrl);
        //            }
        //            else
        //            {
        ////                l.Add(SelfLink(uri));
        //            }
        //
        //            return l;
        //        }
        //
        //        public static IEnumerable<Form> Forms(object po)
        //        {
        //            if (po is IWebActions)
        //            {
        //                var l = new List<Form>();
        //                //l.Add(SelfForm(uri));
        //                if (po is ISelf)
        //                {
        //                    //l.Add(SelfLink((po as ISelf).SelfUrl(), ToString(po)));
        //                }
        //                //l.Add(SelfLink(uri, ToString(po)));
        //                l.AddRange((po as IWebActions).ListActions.OfType<Form>());
        //                return l;
        //            }
        //            else if (po is List<GlobalEventType>)
        //            {
        //                return new List<Form>
        //                {
        //                    new GlobalEventTypeController().FormAdd(),
        //                    //GlobalEventTypeController.FormAddLink()
        //                };
        //            }
        //            else if (po is List<Prop<ProcInst>> || po is List<Prop<ActivityAction>> || po is List<Prop<ProcDef>>)
        //            {
        //                throw new NotSupportedException("NYI");
        ////                return PropsController.PropListForms(uri);
        //            }
        //            else
        //            {
        //                return new Form[0];
        //            }
        //        }
        //
        //        public static bool IsPersistedObject(Type t)
        //        {
        //            while (t.BaseType != null)
        //            {
        //                if (t.Name.StartsWith(typeof(PersistedObject<>).Name)) return true;
        //                t = t.BaseType;
        //            }
        //            //throw new Exception("name: " + t.Name); 
        //            return false;
        //        }
        
        public static bool ShouldInclude(MemberInfo mi)
        {
            if (mi.HasAttr<JsonIgnoreAttribute>())
                return false;

            var ignores = new string[]
            {
//                nameof(IWebActions.ListActions),
//                nameof(ProcDef.Xml),
//                nameof(ProcDef.Nodes),
//                nameof(ISelf.SelfUrl),
            };
            return !ignores.Contains(mi.Name);
        }

        public static List<MemberInfo> PropsOf(Type x)
        {
            return x.GetProperties()
                .Cast<MemberInfo>()
                .Concat(x.GetFields(BindingFlags.Instance))
                .Where(ShouldInclude)
                .OrderBy(s1 => Weight(s1.Name)).ThenBy(s => s.Name)
                .ToList();
        }

        public static readonly List<string> Firsts = new List<string>();

        public static readonly List<string> Lasts = new List<string>(); 

        public static int Weight(string propname)
        {
            if (Firsts.Contains(propname)) return Array.IndexOf(Firsts.ToArray(), propname);
            if (Lasts.Contains(propname)) return 1000 + Array.IndexOf(Lasts.ToArray(), propname);
            return 50;
        }

        public static string GetItemType(Type t)
        {
            return t.Name;
        }

        public static string Itemtype(object x)
        {
            return "http://dv8.no/" + x.GetType().GenericFqn();
        }

        public static object TryGetVal(MemberInfo pi, object x)
        {
            try
            {
                return pi is PropertyInfo ? ((PropertyInfo) pi).GetValue(x) : (pi as FieldInfo).GetValue(x);
            }
            catch (Exception e)
            {
                return "Unavailable (" + e.GetType() + ")";
            }
        }
    }
}