using System;
using System.Collections.Generic;

// Fixed implementation that passes all tests
public class PriorityQueue
{
    private class QueueItem
    {
        public string Value { get; set; }
        public int Priority { get; set; }
        
        public QueueItem(string value, int priority)
        {
            Value = value;
            Priority = priority;
        }
    }
    
    private List<QueueItem> items;
    
    public PriorityQueue()
    {
        items = new List<QueueItem>();
    }
    
    public void Enqueue(string value, int priority)
    {
        // Add to the back of the queue
        items.Add(new QueueItem(value, priority));
    }
    
    public string Dequeue()
    {
        // FIX 1: Check if queue is empty and throw exception if it is
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Cannot dequeue from an empty queue.");
        }
        
        // FIX 2: Find the highest priority
        int highestPriority = int.MinValue;
        foreach (var item in items)
        {
            if (item.Priority > highestPriority)
            {
                highestPriority = item.Priority;
            }
        }
        
        // FIX 3: Find the first item with the highest priority (FIFO for same priority)
        int indexToRemove = -1;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Priority == highestPriority)
            {
                indexToRemove = i;
                break;
            }
        }
        
        // Remove and return the value
        string value = items[indexToRemove].Value;
        items.RemoveAt(indexToRemove);
        return value;
    }
    
    public int Count
    {
        get { return items.Count; }
    }
}