using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace MyCSharpApp_01.Dojo;
internal class Bounded_Queue<T>
{
    private readonly List<T> _values;
    public Bounded_Queue(int capacity)
    {
        _values = new(capacity);
    }
    public int Count => _values.Count;
    public int Size => _values.Capacity;

    public void Enqueue(T value)
    {
        while (_values.Count == _values.Capacity)
        {
            // wait until another Thread removes an item
            Thread.Sleep(50);
        }

        _values.Add(value);
    }
    public T Dequeue()
    {
        while (_values.Count == 0)
        {
            // wait until another Thread adds an item
            Thread.Sleep(50);
        }
        var item = _values[0];
        _values.RemoveAt(0);
        return item;
    }

    public bool TryEnqueue(T value, int timeoutMSec)
    {
        var start = DateTime.Now;
        while (_values.Count == _values.Capacity)
        {
            if ((DateTime.Now - start).TotalMilliseconds > timeoutMSec)
                return false;
            Thread.Sleep(50);
        }
        _values.Add(value);
        return true;
    }
    public bool TryDequeue(int timeoutMSec, [MaybeNullWhen(false)] out T value)
    {
        var start = DateTime.Now;
        while (_values.Count == 0)
        {
            if ((DateTime.Now - start).TotalMilliseconds > timeoutMSec)
            {
                value = default;
                return false;
            }
            Thread.Sleep(50);
        }

        value = _values[0]!;
        _values.RemoveAt(0);
        return true;
    }

}

internal class Bounded_Queue_Safe<T>
{
    private readonly ConcurrentQueue<T> _values;
    public Bounded_Queue_Safe(int capacity)
    {
        _values = new();
        Size = capacity;
    }
    public int Count => _values.Count;
    public int Size { get; }

    public void Enqueue(T value)
    {
        while (_values.Count == Size)
        {
            // wait until another Thread removes an item
            Thread.Sleep(50);
        }

        _values.Enqueue(value);
    }
    public T Dequeue()
    {
        T? item;
        while (!_values.TryDequeue(out item))
        {
            // wait until another Thread adds an item
            Thread.Sleep(50);
        }
        return item;
    }
    public bool TryEnqueue(T value, int timeoutMSec)
    {
        var start = DateTime.Now;
        while (_values.Count == Size)
        {
            if ((DateTime.Now - start).TotalMilliseconds > timeoutMSec)
                return false;
            Thread.Sleep(50);
        }
        _values.Enqueue(value);
        return true;
    }
    public bool TryDequeue(int timeoutMSec, [MaybeNullWhen(false)] out T value)
    {
        var start = DateTime.Now;
        while (!_values.TryDequeue(out value))
        {
            if ((DateTime.Now - start).TotalMilliseconds > timeoutMSec)
                return false;
            Thread.Sleep(50);
        }
        return true;
    }
}
