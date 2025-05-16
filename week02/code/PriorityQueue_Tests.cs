using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueue_Tests
{
    [TestMethod]
    public void Enqueue_AddsItemCorrectly()
    {
        // Summary: Enqueue adds item; Dequeue should return that item
        var queue = new PriorityQueue();
        queue.Enqueue("A", 1);
        Assert.AreEqual("A", queue.Dequeue());
    }

    [TestMethod]
    public void Dequeue_RemovesHighestPriority()
    {
        // Summary: Verifies highest priority item is dequeued
        var queue = new PriorityQueue();
        queue.Enqueue("Low", 1);
        queue.Enqueue("High", 5);
        queue.Enqueue("Medium", 3);

        var result = queue.Dequeue();
        Assert.AreEqual("High", result);
    }

    [TestMethod]
    public void Dequeue_RemovesFirstInWithSamePriority()
    {
        // Summary: Ensures FIFO is respected for items with same priority
        var queue = new PriorityQueue();
        queue.Enqueue("FirstHigh", 5);
        queue.Enqueue("SecondHigh", 5);
        Assert.AreEqual("FirstHigh", queue.Dequeue());
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Dequeue_ThrowsOnEmptyQueue()
    {
        // Summary: Verifies Dequeue throws exception on empty queue
        var queue = new PriorityQueue();
        queue.Dequeue(); // should throw
    }
}
