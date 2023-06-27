using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lnk_Lst;
internal class LnkListItem<T> where T : class
{
    private readonly T _value;
    private int? _previous;
    private int? _next;

    internal LnkListItem(
        T value,
        int index,
        int? previous,
        int? next)
    {
        _value = value;
        Index = index;
        _previous = previous;
        _next = next;
    }

    internal int Index { get; }

    internal T GetValue()
    {
        return _value;
    }


    internal int? Previous()
    {
        return _previous;
    }

    internal int? Next()
    {
        return _next;
    }

    internal void UpdatePreviousIndex(int? index)
    {
        _previous = index;
    }

    internal void UpdateNextIndex(int? index)
    {
        _next = index;
    }
}
