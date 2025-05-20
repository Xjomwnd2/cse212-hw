using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueue_Tests
{
    [TestMethod]
    public void Enqueue_AddsItemCorrectly()
    {
        // Summary: Enqueue adds item; Dequeue should return that item
        // Defect(s) Found (if any): None apparent in this basic add and remove scenario.
        var queue = new PriorityQueue();
        queue.Enqueue("A", 1);
        Assert.AreEqual("A", queue.Dequeue());
    }

    [TestMethod]
    public void Dequeue_RemovesHighestPriority()
    {
        // Summary: Verifies highest priority item is dequeued
        // Defect(s) Found (if any): Potential defect if the internal implementation doesn't correctly track and order elements by priority. A naive implementation might dequeue based on insertion order instead of priority.
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
        // Defect(s) Found (if any): A potential defect could be that items with the same priority are not dequeued in the order they were enqueued (violating FIFO). The implementation needs to maintain insertion order for equal priorities.
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
        // Defect(s) Found (if any): A defect would be if calling Dequeue on an empty queue does not throw an `InvalidOperationException`, leading to unexpected behavior or errors.
        var queue = new PriorityQueue();
        queue.Dequeue(); // should throw
    }
}