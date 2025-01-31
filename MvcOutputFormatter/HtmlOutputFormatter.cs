// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using System.Xml;
// using DV8.Html.Elements;
// using DV8.Html.Framework;
// using DV8.Html.Mutators;
// using DV8.Html.Serialization;
// using DV8.Html.Support;
// using DV8.Html.Utils;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc.Formatters;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Net.Http.Headers;
// using Nodes.API.Models;
// using Nodes.API.Queries;
// using Nodes.API.Support;
// using Nodes.API.Support.ExtensionMethods;
// using TimeZoneInfo = System.TimeZoneInfo;
// using static DV8.Html.Prefixes.Underscore;
//
// //using Link = Nodes.API.Support.Link;
//
// namespace Nodes.API.SharedKernel.Controllers.Html;
//
// public class HtmlOutputFormatter : TextOutputFormatter
// {
//     public HtmlOutputFormatter()
//     {
//         SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/html"));
//         SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/html"));
// //            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(ProblemDetailsException.ContentType));
//         SupportedEncodings.Add(Encoding.UTF8);
//     }
//
//     public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context,
//         Encoding selectedEncoding)
//     {
//         var elements = SerializeResult(context.Object, context);
//
//         var bare = context.ContentType.StartsWith("application/html", StringComparison.OrdinalIgnoreCase);
//         var html = bare ? elements : MakeCompleteHtml(elements.ToArray());
//         if (bare)
//         {
//             // Workaround stupid browsers not showing this
//             context.ContentType = "text/html";
//             context.HttpContext.Response.ContentType = "text/html";
//         }
//
//         if (context.ContentType.ToString()!.Contains(ProblemDetailsException.ContentType))
//         {
//             context.ContentType = "text/html";
//             context.HttpContext.Response.ContentType = "text/html";
//         }
//
//         await context.HttpContext.Response.WriteAsync(html.ToHtml());
//     }
//
//     public static DV8.Html.Elements.Html MakeCompleteHtml(IEnumerable<IHtmlElement> elements)
//     {
//         var html = _<DV8.Html.Elements.Html>(
//             _<Head>(
//                 new Link
//                 {
//                     Media = "screen",
//                     Rel = "stylesheet",
//                     Href = "/static/api.css",
//                 },
//                 new Link
//                 {
//                     Media = "screen",
//                     Rel = "stylesheet",
//                     Href = "https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css",
//                 },
//                 new Script
//                 {
//                     Src = "/static/api.js",
//                 }
//             ),
//             _<Body>(
//                 Array.Empty<IHtmlElement>()
//                     .Concat(new Div(new A("/", $"NODES API vr {NodesApiVersion.ApiVersion}")).ToArray())
//                     .Concat(new Div(elements.ToArray()).ToArray())
//                     .Concat(new Div(new A("/", $"NODES API vr {NodesApiVersion.ApiVersion}")).ToArray())
//                     .ToArray())
//         );
//         return html;
//     }
//
//     public static IHtmlElement SerializeResult(object obj, OutputFormatterWriteContext ctx)
//     {
//         var ser = ctx.HttpContext.RequestServices.GetRequiredService<HtmlSerializerRegistry>();
//         return SerializeResult(obj, ser);
//     }
//     
//     public static IHtmlElement SerializeResult(object obj, HtmlSerializerRegistry ser)
//     {
//     
//         // IHtmlSerializer ser = CreateHtmlSerializerRegistry(ctx);
//         IEnumerable<IHtmlElement> elements;
//         if (obj is IEnumerable<IHasLinks> enumerable)
//         {
//             var typeName = LangUtils.GetAnyElementType(obj.GetType()).Name.ToLower();
//             var list = enumerable.ToList();
//             if (list.Any())
//             {
//                 elements = new H1($"List of {list.Count} {typeName}s: ")
//                     .ToArray().Concat(ser.Serialize(obj, 3, ser).Select(o => new Li(o)));
//             }
//             else
//             {
//                 elements = new P($"Empty list of {typeName}s").ToArray();
//             }
//         }
//         else
//         {
//             elements = ser.Serialize(obj, 3, ser);
//         }
//
//         return _<Div>(
//             elements.ToList()
//         ).WithClass("results");
//     }
//
//     public static string PostProcessApiUrl(string href) =>
//         IsStandardApiUrl(href)
//             ? href
//             : "/api" + href;
//
//     private static bool IsStandardApiUrl(string href) =>
//         href.StartsWith("/api/");
//
//     public static A LinkToAnchor(NodesLink l) =>
//         new A(PostProcessApiUrl(l.Href), l.Title, l.Rel).WithClass(l.Method);
//
//     public static HtmlSerializerRegistry CreateHtmlSerializerRegistryWithoutDefault(
//         OutputFormatterWriteContext ctx = null)
//     {
//         if (!HtmlSupport.Lasts.Contains("Links"))
//         {
//             HtmlSupport.Lasts.Add("Links");
//         }
//
//         if (!HtmlSupport.Firsts.Contains("Id"))
//         {
//             HtmlSupport.Firsts.Add("Id");
//         }
//
//         var ser = new HtmlSerializerRegistry();
//
//             // ser.Add(o => o is SettlementReport, o =>
//             // {
//             //     if (ctx == null)
//             //         throw new ArgumentException("Cant serialize settlement reports without full context");
//             //     var sp = ctx.HttpContext.RequestServices;
//             //     Div html;
//             //     if (o is LongFlexSettlementReport report)
//             //     {
//             //         var rg = sp.GetRequiredService<ILongFlexSettlementReportGenerator>();
//             //         html = rg.SerializeToHtml(report);
//             //     }
//             //     else
//             //     {
//             //         var rg = sp.GetRequiredService<ISettlementReportSerializer>();
//             //         html = rg.SerializeToHtml((SettlementReport)o);
//             //     }
//             //
//             //     return html.ToArray();
//             // });
//
//         ser.Add(o => o is DateTimeOffset, o => new Span(((DateTimeOffset)o).ToIso()).ToArray());
//         ser.Add(o => o is NodesLink, o => LinkToAnchor(o as NodesLink).ToArray());
//         ser.Add(o => o is DTOBase, o => new PropsSerializer { IncludeType = false }.Serialize(o, 3, ser));
//         ser.Add(o => o is Enumeration, o => new Span(o.ToString()).ToArray());
//         // ser.Add(Reflect.IsNonPrimitive, o => new PropsSerializer {IncludeType = false}.Serialize(o, 3, ser));
//         // ser.Add(o=>true, o => new PropsSerializer {IncludeType = false}.Serialize(o, 3, ser));
//
//         ser.Add(o => o is IHtmlElement, o => ((IHtmlElement)o)!.ToArray());
//         ser.Add(o => !Reflect.IsNonPrimitive(o), o => new Span(o.ToString()).ToArray());
//
//         ser.Add(o => o is Dictionary<string, string>, o => _<Ul>(
//                 ((Dictionary<string, string>)o).Select(kvp => _<Li>(
//                         new Dt(kvp.Key),
//                         new Dd(kvp.Value)
//                     )
//                 )).ToArray()
//         );
//         // This is to fix Embedded-list so that it shows "Type" for each item. 
//         ser.Add(o => o is IEnumerable && o.GetType().GetGenericArguments().FirstOrDefault() == typeof(IHasLinks),
//             o =>
//                 _<Ul>(
//                     ((IEnumerable<IHasLinks>)o).Select(dto => _<Li>(
//                             new PropsSerializer { IncludeType = true }.Serialize(dto, 3, ser).ToList()
//                         )
//                     )).ToArray()
//         );
//
//
//         // Add tz hack: 
//         ser.Add(new FuncHtmlSerializer(x => x is TimeSpan, x => new[] { new P(XmlConvert.ToString((TimeSpan)x)) }));
//         var facWithTzAsNoOp = new HtmlSerializerRegistry();
//         facWithTzAsNoOp.Serializers.AddRange(ser.Serializers);
//         facWithTzAsNoOp
//             .Add(new FuncHtmlSerializer(x => x is TimeZoneInfo, _ => Enumerable.Empty<IHtmlElement>()));
//         var tzOneOp = new FuncHtmlSerializer(x => x is TimeZoneInfo,
//             x => new PropsSerializer().Serialize(x, 1, facWithTzAsNoOp));
//         ser.Add(tzOneOp);
//
//         ser.Add(o => o is IEnumerable, o => new ListSerializer().Serialize(o, 3, ser));
//
//         ser.Add(o => o is IDictionary, o => new ListSerializer().Serialize((IDictionary)o, 3, ser));
//
//
//         // Add a special case for search-result, changing order of things: 
//         ser.Add(o => o != null && o.GetType().Name.StartsWith("SearchResult"), o =>
//         {
//             var props = HtmlSupport.PropsOf(o.GetType())
//                 .Where(x => x.Name != nameof(SearchResult<DTOBase>.Id))
//                 .OrderBy(p => p.Name switch
//                 {
//                     nameof(SearchResult<User>.Items) => 1,
//                     nameof(SearchResult<User>.Embedded) => 2,
//                     _ => 0
//                 });
//             return PropsSerializer.SerializeProps(o, 3, ser, props, false);
//         });
//         return ser;
//     }
//
//     public static HtmlSerializerRegistry CreateHtmlSerializerRegistry(OutputFormatterWriteContext ctx = null)
//     {
//         var ser = CreateHtmlSerializerRegistryWithoutDefault(ctx);
//         ser.Add(Reflect.IsNonPrimitive, o => new PropsSerializer { IncludeType = false }.Serialize(o, 3, ser));
//         return ser;
//     }
// }