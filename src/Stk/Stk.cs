using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stk;
public class Stk<T> where T : class
{
    private StkItem<T>[] _items = default!;
    private int _head;

    public Stk() { _head = -1; }

    public Stk(T value)
    {
        _head = -1;
        _items = new StkItem<T>[] { 
        new StkItem<T>((_head + 1), _head, value)};
        _head++;
    }
    public Stk(IEnumerable<T> values) 
    {
        _head = -1;
        var count = values.Count();
        _items = new StkItem<T>[count];

        foreach (var value in values)
        {
            _items[_head + 1] = new StkItem<T>(
                (_head + 1),
                _head,
                value);

            _head++;
        }
    }

    public void Push(T value)
    {
        if(_head == -1) _items = new StkItem<T>[1];

        var count = _items.Length;
        if (_head == (count - 1))
        {
            ExtendArray(count);
        }

        _items[_head + 1] = new StkItem<T>(
            _head + 1, _head, value);

        _head++;
    }

    public T Peek()
    {
        if (_head < 0) return default!;

        var value = _items[_head].Value;
        return value;
    }

    public T Pop()
    {
        var value = Peek();
        if (_head > -1) _head--;
        return value;
    }

    private void ExtendArray(int count)
    {
        var newArray = new StkItem<T>[count + 1];

        for (int i = 0; i < count; i++)
        {
            newArray[i] = _items[i];
        }
        
        _items = newArray;
    }
}
