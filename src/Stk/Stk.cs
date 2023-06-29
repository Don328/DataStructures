using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stk;
public class Stk<T> where T : class
{
    private StkItem<T>[] _items = default!;
    private int _tail;

    public Stk() { _tail = -1; }

    public Stk(T value)
    {
        _tail = -1;
        _items = new StkItem<T>[] { 
        new StkItem<T>((_tail + 1), _tail, value)};
        _tail++;
    }
    public Stk(IEnumerable<T> values) 
    {
        _tail = -1;
        var count = values.Count();
        _items = new StkItem<T>[count];

        foreach (var value in values)
        {
            _items[_tail + 1] = new StkItem<T>(
                (_tail + 1),
                _tail,
                value);

            _tail++;
        }
    }

    public void Push(T value)
    {
        if(_tail == -1) _items = new StkItem<T>[1];

        var count = _items.Length;
        if (_tail == (count - 1))
        {
            ExtendArray(count);
        }

        _items[_tail + 1] = new StkItem<T>(
            _tail + 1, _tail, value);

        _tail++;
    }

    public T Peek()
    {
        if (_tail < 0) return default!;

        var value = _items[_tail].Value;
        return value;
    }

    public T Pop()
    {
        var value = Peek();
        if (_tail > -1) _tail--;
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
