using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Que;
public class Que<T> where T : class
{
    private T[] _items = default!;
    private int _head;
    private int _tail;

    public Que() { }
    public Que(T item) { }
    public Que(IEnumerable<T> items) { }

    public void Push(T item)
    {
        var newCount = _tail - _head + 2;
        var newTail = newCount - 1;
        var newItems = new T[newCount];
        newItems[newTail] = item;
        
        for (int i = _head; i < _tail; i++)
        {
            newItems[i - _head] = _items[i];
        }

        _items = newItems;
        _head = 0;
        _tail = newTail;
    }

    public T Peek()
    {
        if (_head > _tail) return default!;
        
        return _items[_head];
    }

    public T Pop()
    {
        if (_head > _tail) return default!;
        
        var value = _items[_head];
        _head++;
        return value;
    }
}
