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

        // Initialize with the first item
        int highestPriorityIndex = 0;
        int highestPriority = items[0].Priority;
        int lowestOrder = items[0].Order;

        // Find the item with highest priority and, if tied, the lowest order (FIFO)
        for (int i = 1; i < items.Count; i++)
        {
            QueueItem item = items[i];
            
            // If this item has higher priority, it becomes the new candidate
            if (item.Priority > highestPriority)
            {
                highestPriorityIndex = i;
                highestPriority = item.Priority;
                lowestOrder = item.Order;
            }
            // If this item has the same priority but was added earlier (lower order)
            else if (item.Priority == highestPriority && item.Order < lowestOrder)
            {
                highestPriorityIndex = i;
                lowestOrder = item.Order;
            }
        }

        // Get the item to return
        QueueItem highestPriorityItem = items[highestPriorityIndex];
        
        // Remove it from the list
        items.RemoveAt(highestPriorityIndex);
        
        return highestPriorityItem.Value;
    }
}