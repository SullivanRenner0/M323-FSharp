using System;
using System.Linq;

namespace MyCSharpApp_01.Dojo;
internal class RingBuffer<T>
{
    private readonly List<T> _values;
    public RingBuffer(int capacity)
    {
        _values = new List<T>(capacity);
    }

    public void Add(T value)
    {
        if (_values.Count == _values.Capacity)
            _values.RemoveAt(0);
        _values.Add(value);
    }
    public T Take()
    {
        if (_values.Count == 0)
            throw new InvalidOperationException("Buffer is empty");
        var value = _values[0];
        _values.RemoveAt(0);
        return value;
    }

    public int Count => _values.Count;
    public int Size => _values.Capacity;
}
