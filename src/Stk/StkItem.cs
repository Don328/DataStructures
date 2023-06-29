using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stk;
public class StkItem<T> where T : class
{

    public StkItem(
        int index,
        int nextIndex,
        T value)
    {
        Index = index;
        NextIndex = nextIndex;
        Value = value;
    }

    public int Index { get; private set; }
    public int NextIndex { get; private set; } = -1;
    public T Value { get; private set; }
}
