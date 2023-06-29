namespace Que;

public class Que<T> where T : class
{
    private T[] _items = default!;
    private int _cursor;
    private int _tail;

    public Que() 
    {
        GetEmptyQue();
    }
    public Que(T item) 
    {
        _items = new T[1];
        _cursor = 0;
        _tail = 0;
    }
    public Que(IEnumerable<T> items) 
    {
        _cursor = 0;
        _tail = -1;
        var count = items.Count();
        _items = new T[count];

        foreach (var item in items)
        {
            _items[++_tail] = item;
        }
    }

    public void Push(T item)
    {
        if (_cursor == -1)
        {
            _items = new T[1];
            _items[0] = item;
            _cursor = 0;
            _tail = 0;
            return;
        }

        var newCount = _tail - _cursor + 2;
        var newTail = newCount - 1;
        var newItems = new T[newCount];
        newItems[newTail] = item;

        for (int i = _cursor; i <= _tail; i++)
        {
            var newIndex = (i - _cursor);
            newItems[newIndex] = _items[i];
        }

        _items = newItems;
        _cursor = 0;
        _tail = newTail;
    }

    public T Peek()
    {
        if (_cursor > _tail) return default!;
        
        return _items[_cursor];
    }

    public T Pop()
    {
        if (_cursor > _tail) return default!;
        
        var value = _items[_cursor];
        _cursor++;

        if (_cursor > _tail)
        {
            GetEmptyQue();
        }
        
        return value;
    }

    private void GetEmptyQue()
    {
        _items = Array.Empty<T>();
        _cursor = -1;
        _tail = -1;
    }
}
