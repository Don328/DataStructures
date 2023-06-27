using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList;
public class LinkedListItem<T> where T : class
{
    private readonly T _value;
    private readonly int _index;
    private int? _previous;
    private int? _next;

    public LinkedListItem(
        T value,
        int index,
        int? previous,
        int? next)
    {
        _value = value;
        _index = index;
        _previous = previous;
        _next = next;
    }

    public int Index { get; }
    
    public T GetValue()
    {
        return _value;
    }


    public int? Previous()
    {
        return _previous;
    }

    public int? Next()
    {
        return _next;
    }

    public void UpdatePreviousIndex(int? index)
    {
        _previous = index;
    }

    public void UpdateNextIndex(int? index)
    {
        _next = index;
    }
}
