namespace Lnk_Lst;
public class LnkList<T> where T : class
{
    private LnkListItem<T>?[] _items = default!;
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

    public T Start()
    {
        _cursor = _head;
        return Get();
    }

    public T Start_Reverse()
    {
        _cursor = _tail;
        return Get();
    }

    public T Get()
    {
        if (_cursor == -1) return default!;

        return GetItemUnderCursor().GetValue();
    }

    public T PeekFirst()
    {
        var item = _items[_head] ?? default!;
        return item.GetValue();
    }

    public T PeekLast()
    {
        var item = _items[_tail] ?? default!;
        return item.GetValue();
    }

    public T Next()
    {
        _cursor = GetItemUnderCursor().Next() ?? _head;
        return Get();
    }

    public T PeekNext()
    {
        var index = GetItemUnderCursor().Next()?? _head;
        var next = _items[index];
        
        if (next == null) return default!;
        return next.GetValue();
    }

    public T Previous()
    {
        _cursor = GetItemUnderCursor().Previous() ?? _tail;
        return Get();
    }

    public T PeekPrevious()
    {
        var index = GetItemUnderCursor()
            .Previous() ?? _head;
        
        var previous = _items[index];

        if (previous == null) return default!;
        return previous.GetValue();
    }

    public void Add(T item)
    {
        LnkListItem<T>?[] items;

        if (_items == null) items = new LnkListItem<T>?[1];
        else
        {
            items = new LnkListItem<T>?[_items.Length + 1];
            for (int i = 0; i < _items.Length; i++)
            {
                items[i] = _items[i];
            }
        }

        _items = items;
        var index = _items.Length - 1;
        _items[index] = new LnkListItem<T>(
            value: item, index: index, previous: _tail, next: _head);
        var previous = _items[_tail];
        previous?.UpdateNextIndex(index);
        var next = _items[_head];
        next?.UpdatePreviousIndex(index);

        _tail = index;
    }

    public void Insert(T value, int priorToIdx)
    {
        var previous = _items[priorToIdx] ?? _items[_tail];
        var next = _items[previous.Next() ?? 0] ?? _items[_head];
        var index = _items.Length;

        var item = new LnkListItem<T>(
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

        LnkListItem<T>? previous;
        LnkListItem<T>? next;

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

    private LnkListItem<T> GetItemUnderCursor()
    {
        return _items[_cursor] ?? default!;
    }
}
