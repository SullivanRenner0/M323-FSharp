using System;
using System.Linq;

namespace MyCSharpApp_01.Dojo;
internal class PriorityQueue<T>
{
    private readonly List<(T item, int prio)> queue = [];
    public void Enqueue(T item, int priority)
    {
        var i = queue.FindLastIndex(x => x.prio >= priority);
        if (i == -1)
            queue.Insert(0, (item, priority));
        else
            queue.Insert(i + 1, (item, priority));
    }
    public T Dequeue()
    {
        var item = queue.First();
        queue.RemoveAt(0);
        return item.item;
    }
    public int Count() => queue.Count;
}
