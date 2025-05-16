using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private class QueueItem
    {
        public string Value { get; }
        public int Priority { get; }
        public int Order { get; }

        public QueueItem(string value, int priority, int order)
        {
            Value = value;
            Priority = priority;
            Order = order;
        }
    }

    private List<QueueItem> items;
    private int orderCounter;

    public PriorityQueue()
    {
        items = new List<QueueItem>();
        orderCounter = 0;
    }

    public void Enqueue(string value, int priority)
    {
        items.Add(new QueueItem(value, priority, orderCounter++));
    }

    public string Dequeue()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        QueueItem highestPriorityItem = items[0];
        foreach (var item in items)
        {
            if (item.Priority > highestPriorityItem.Priority ||
               (item.Priority == highestPriorityItem.Priority && item.Order < highestPriorityItem.Order))
            {
                highestPriorityItem = item;
            }
        }

        items.Remove(highestPriorityItem);
        return highestPriorityItem.Value;
    }
}
