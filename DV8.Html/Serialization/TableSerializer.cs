using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DV8.Html.Elements;
using DV8.Html.Framework;
using DV8.Html.Support;
using static DV8.Html.Prefixes.Underscore;

namespace DV8.Html.Serialization;

public class TableSerializer : IHtmlSerializer
{
    private readonly MemberInfo[] _props;
    private readonly HtmlSerializerRegistry _rootSerializer;

    public TableSerializer(MemberInfo[] props, HtmlSerializerRegistry rootSerializer)
    {
        _props = props;
        _rootSerializer = rootSerializer;
    }

    public bool CanSerialize(object x)
    {
        return x is IEnumerable<object>;
    }

    public IEnumerable<IHtmlElement> Serialize(object o, int lvl, IHtmlSerializer fac)
    {
        yield return SerializeToTable((IEnumerable)o);
    }

    public HtmlElement SerializeToTable(IEnumerable list) =>
        _<Table>(
            _<Thead>(
                _props.Select(p => new Th(p.Name))
            ),
            _<Tbody>(
                list.Cast<object>().Select(item => SerializeToRow(_props, item))
            )
        );

    public IHtmlElement SerializeToRow(IEnumerable<MemberInfo> props, object item) =>
        _<Tr>(
            props.Select(prop => SerializeToTd(prop, item))
        );

    public Td SerializeToTd(MemberInfo prop, object item)
    {
        var val = HtmlSupport.TryGetVal(prop, item);
        if (val is List<Linking>)
        {
            val = (val as List<Linking>).OfType<A>().ToList();
        }

        var element = _rootSerializer.Serialize(val, 2, _rootSerializer);
        return element != null ? new Td { Subs = element.ToList() } : new Td(val?.ToString());
    }
}