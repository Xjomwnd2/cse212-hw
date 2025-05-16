using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Basic Enqueue and Dequeue Operation
    // Expected Result: The item that was enqueued should be dequeued successfully
    // Defect(s) Found: None for this basic case
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        
        string result = priorityQueue.Dequeue();
        
        Assert.AreEqual("Item1", result);
    }

    [TestMethod]
    // Scenario: Priority Order Dequeue - Test that higher priority items are dequeued before lower priority items
    // Expected Result: Items should be dequeued in priority order (highest first)
    // Defect(s) Found: The Dequeue method was not correctly finding the highest priority item
    // It was retrieving items in FIFO order regardless of priority
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 2);
        priorityQueue.Enqueue("Medium", 1);
        
        Assert.AreEqual("High", priorityQueue.Dequeue(), "Highest priority item should be dequeued first");
        Assert.AreEqual("Low", priorityQueue.Dequeue(), "When same priority, FIFO order should be followed");
        Assert.AreEqual("Medium", priorityQueue.Dequeue(), "Last item should be dequeued last");
    }

    [TestMethod]
    // Scenario: FIFO Order for Same Priority - When multiple items have the same priority, they should be dequeued in FIFO order
    // Expected Result: Items with the same priority should be dequeued in the order they were added
    // Defect(s) Found: When dequeuing items with the same priority, the implementation was not respecting FIFO order
    // It was taking the last item added with that priority instead of the first one
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 1);
        priorityQueue.Enqueue("Third", 1);
        
        Assert.AreEqual("First", priorityQueue.Dequeue(), "First item added should be dequeued first");
        Assert.AreEqual("Second", priorityQueue.Dequeue(), "Second item added should be dequeued second");
        Assert.AreEqual("Third", priorityQueue.Dequeue(), "Third item added should be dequeued third");
    }

    [TestMethod]
    // Scenario: Complex Priority Ordering - Testing more complex interactions between priorities
    // Expected Result: Items should always be dequeued in order of priority, with FIFO ordering for same priorities
    // Defect(s) Found: The implementation was not consistently prioritizing higher priority items
    // and was not maintaining FIFO order for same priority items
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 2);
        priorityQueue.Enqueue("E", 1);
        
        Assert.AreEqual("C", priorityQueue.Dequeue(), "Highest priority (3) should be dequeued first");
        Assert.AreEqual("A", priorityQueue.Dequeue(), "First item with priority 2 should be dequeued next");
        Assert.AreEqual("D", priorityQueue.Dequeue(), "Second item with priority 2 should be dequeued next");
        Assert.AreEqual("B", priorityQueue.Dequeue(), "First item with priority 1 should be dequeued next");
        Assert.AreEqual("E", priorityQueue.Dequeue(), "Second item with priority 1 should be dequeued last");
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    // Scenario: Dequeue from Empty Queue - Test that an exception is thrown when attempting to dequeue from an empty queue
    // Expected Result: An InvalidOperationException should be thrown
    // Defect(s) Found: The implementation was not throwing an exception when attempting to dequeue from an empty queue
    // It was returning null or a default value instead
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        
        string result = priorityQueue.Dequeue(); // This should throw an InvalidOperationException
    }

    [TestMethod]
    // Scenario: Mixed Operations - Test a mix of operations to ensure the queue maintains correct behavior
    // Expected Result: Items should be dequeued in the correct order after various operations
    // Defect(s) Found: After multiple operations, the queue was not maintaining correct priority and FIFO ordering
    public void TestPriorityQueue_6()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        
        Assert.AreEqual("B", priorityQueue.Dequeue(), "Higher priority item should be dequeued first");
        
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 1);
        
        Assert.AreEqual("C", priorityQueue.Dequeue(), "Highest priority item should be dequeued next");
        Assert.AreEqual("A", priorityQueue.Dequeue(), "Original item with priority 1 should be dequeued next");
        Assert.AreEqual("D", priorityQueue.Dequeue(), "Last item with priority 1 should be dequeued last");
    }
}