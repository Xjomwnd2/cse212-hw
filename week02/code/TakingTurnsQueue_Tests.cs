using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class TakingTurnsQueue_Tests
{
    // ✅ Test passed. Person with finite turns is removed after final turn.
    [TestMethod]
    public void PersonWithFiniteTurns_RemovedAfterLastTurn()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Alice", 1);

        Assert.AreEqual("Alice", queue.GetNextPerson());

        Assert.ThrowsException<InvalidOperationException>(() => queue.GetNextPerson());
    }

    // ✅ Test passed. Person with infinite turns is re-added correctly.
    [TestMethod]
    public void PersonWithInfiniteTurns_StaysInQueue()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Bob", 0);

        Assert.AreEqual("Bob", queue.GetNextPerson());
        Assert.AreEqual("Bob", queue.GetNextPerson());
        Assert.AreEqual("Bob", queue.GetNextPerson());
    }

    // ✅ Test passed. Multiple people cycle correctly through the queue.
    [TestMethod]
    public void MultiplePeople_CycleAsExpected()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Alice", 2); // 2 turns
        queue.AddPerson("Bob", 0);   // infinite turns

        Assert.AreEqual("Alice", queue.GetNextPerson()); // Alice 1
        Assert.AreEqual("Bob", queue.GetNextPerson());   // Bob ∞
        Assert.AreEqual("Alice", queue.GetNextPerson()); // Alice 0 (removed)
        Assert.AreEqual("Bob", queue.GetNextPerson());   // Bob ∞
        Assert.AreEqual("Bob", queue.GetNextPerson());   // Bob ∞ again
    }

    // ✅ Test passed. Exception thrown when getting person from empty queue.
    [TestMethod]
    public void EmptyQueue_ThrowsException()
    {
        var queue = new TakingTurnsQueue();

        Assert.ThrowsException<InvalidOperationException>(() => queue.GetNextPerson());
    }
}
