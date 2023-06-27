using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList;
public class LnkList<T> where T : class
{
    private LinkedListItem<T>?[] _items = default!;
    private int _cursor = 0;
    private int _head = 0;
    private int _tail = 0;

    public LnkList() { }

    public LnkList(T item)
    {
        Add(item);
    }

    public LnkList(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }

    public T Get()
    {
        if (_cursor == -1) return default!;

        return GetItemUnderCursor().GetValue();
    }

    public T GetNext()
    {
        var currentItem = GetItemUnderCursor();
        var next = currentItem.Next();

        _cursor = next ?? _head;
        //_cursor = GetItemUnderCursor().Next()?? _head;
        return Get();
    }

    public T GetPrevious()
    {
        _cursor = GetItemUnderCursor().Previous()?? _tail;
        return Get();
    }

    public void Add(T item)
    {
        LinkedListItem<T>?[] items;

        if (_items == null) items = new LinkedListItem<T>?[1];
        else
        {
            items = new LinkedListItem<T>?[_items.Length + 1];
            for (int i = 0; i < _items.Length; i++)
            {
                items[i] = _items[i];
            }
        }

        _items = items;
        var index = _items.Length - 1;
        _items[index] = new LinkedListItem<T>(
            value: item, index: index, previous: _tail, next: _head);
        var previous = _items[_tail];
        if (previous != null) previous.UpdateNextIndex(index);

        _tail = index;
    }

    public void Insert(T value, int priorToIdx)
    {
        var previous = _items[priorToIdx]?? _items[_tail];
        var next = _items[previous.Next() ?? 0]?? _items[_head];
        var index = _items.Length;

        var item = new LinkedListItem<T>(
            value: value, 
            index: index, 
            previous: previous.Index, 
            next: next.Index);

        _items[index] = item;
        previous?.UpdateNextIndex(index);
        next.UpdatePreviousIndex(index);
        _tail = index;
    }

    public void Remove()
    {
        var item = _items[_cursor];
        if (item == null) return;

        LinkedListItem<T>? previous;
        LinkedListItem<T>? next;

        try { previous = _items[item.Previous() ?? -1]; }
        catch { previous = null; }
        try { next = _items[item.Next() ?? -1]; }
        catch { next = null; }

        _items[_cursor] = null;

        if (previous != null)
        {
            if (next != null)
            {
                previous.UpdateNextIndex(next.Index);
                next.UpdatePreviousIndex(previous.Index);
            }
            else
            {
                previous.UpdateNextIndex(null);
            }
            
            _cursor++;
        }
        else
        {
            if (next != null)
            {
                next.UpdatePreviousIndex(null);
                _cursor--;
            }
            else
            {
                Clear();
            }
        }
    }

    public LnkList<T> Clear()
    {
        _items = default!;
        _cursor = 0;
        _tail = 0;

        return this;
    }

    private LinkedListItem<T> GetItemUnderCursor()
    {
        return _items[_cursor]?? default!;
    }
}
