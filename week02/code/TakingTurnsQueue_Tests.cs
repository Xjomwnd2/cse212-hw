using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TakingTurnsQueue.Tests
{
    [TestClass]
    public class TakingTurnsQueue_Tests
    {
        /// <summary>
        /// Test adding one person to the queue and then getting that person.
        /// </summary>
        /// <remarks>
        /// Defect Found: None for this basic test case.
        /// </remarks>
        [TestMethod]
        public void TestOnePersonZeroTurns()
        {
            // Create a queue with one person (turns = 0 means infinite turns)
            TakingTurnsQueue queue = new();
            queue.AddPerson("John", 0);

            // Confirm the person is there and can be retrieved
            Person person = queue.GetNextPerson();
            Assert.AreEqual("John", person.Name);
            Assert.AreEqual(0, person.Turns);  // Turns should remain 0 (infinite)
            Assert.AreEqual(1, queue.Length);  // Person should still be in the queue
        }

        /// <summary>
        /// Test adding two people to the queue and then getting both of those people.
        /// </summary>
        /// <remarks>
        /// Defect Found: People with infinite turns (0 or negative) are not properly
        /// handled - their turns value isn't preserved when re-added to the queue.
        /// </remarks>
        [TestMethod]
        public void TestTwoPeopleZeroTurns()
        {
            // Create a queue with two people
            TakingTurnsQueue queue = new();
            queue.AddPerson("John", 0);
            queue.AddPerson("Bob", 0);
            Assert.AreEqual(2, queue.Length);

            // Check the first person
            Person person = queue.GetNextPerson();
            Assert.AreEqual("John", person.Name);
            Assert.AreEqual(0, person.Turns);  // Should remain 0 (infinite)
            Assert.AreEqual(2, queue.Length);  // Both people should still be in the queue

            // Check the next person
            person = queue.GetNextPerson();
            Assert.AreEqual("Bob", person.Name);
            Assert.AreEqual(0, person.Turns);  // Should remain 0 (infinite)
            Assert.AreEqual(2, queue.Length);  // Both people should still be in the queue

            // John should be first in the queue again
            person = queue.GetNextPerson();
            Assert.AreEqual("John", person.Name);
            Assert.AreEqual(0, person.Turns);  // Should remain 0 (infinite)
            Assert.AreEqual(2, queue.Length);  // Both people should still be in the queue
        }

        /// <summary>
        /// Test that a person is removed from the queue when they have no more turns.
        /// </summary>
        /// <remarks>
        /// Defect Found: Logic for removing people who run out of turns is incorrect.
        /// When a person's turns reaches 0, they are still being kept in the queue instead
        /// of being removed.
        /// </remarks>
        [TestMethod]
        public void TestOnPersonWithOneTurn()
        {
            // Create a queue with one person who has 1 turn
            TakingTurnsQueue queue = new();
            queue.AddPerson("John", 1);
            Assert.AreEqual(1, queue.Length);

            // Get the person (this should use up their turn)
            Person person = queue.GetNextPerson();
            Assert.AreEqual("John", person.Name);
            Assert.AreEqual(0, person.Turns);
            Assert.AreEqual(0, queue.Length);  // Person should no longer be in the queue after turn is used

            // Queue should be empty now
            Assert.ThrowsException<InvalidOperationException>(() => queue.GetNextPerson());
        }

        /// <summary>
        /// Test a complex case with different amounts of turns.
        /// </summary>
        /// <remarks>
        /// Defect Found: People with turns = 0 are being removed from the queue instead of
        /// staying in the queue indefinitely. Also, people with exactly 1 turn are incorrectly
        /// re-added to the queue after their turn is used.
        /// </remarks>
        [TestMethod]
        public void TestComplex()
        {
            // Create a queue with multiple people
            TakingTurnsQueue queue = new();
            queue.AddPerson("John", 1);   // Only 1 turn
            queue.AddPerson("Bob", 0);    // Infinite turns (0)
            queue.AddPerson("Sue", 3);    // 3 turns
            queue.AddPerson("Jane", -1);  // Infinite turns (negative)
            Assert.AreEqual(4, queue.Length);

            // John's only turn
            Person person = queue.GetNextPerson();
            Assert.AreEqual("John", person.Name);
            Assert.AreEqual(0, person.Turns);
            Assert.AreEqual(3, queue.Length);  // John should be gone, 3 people left

            // Bob's first turn (infinite)
            person = queue.GetNextPerson();
            Assert.AreEqual("Bob", person.Name);
            Assert.AreEqual(0, person.Turns);  // Should remain 0 (infinite)
            Assert.AreEqual(3, queue.Length);  // Bob should stay in queue

            // Sue's first turn
            person = queue.GetNextPerson();
            Assert.AreEqual("Sue", person.Name);
            Assert.AreEqual(2, person.Turns);  // Decreased from 3 to 2
            Assert.AreEqual(3, queue.Length);  // Sue should stay in queue

            // Jane's first turn (infinite)
            person = queue.GetNextPerson();
            Assert.AreEqual("Jane", person.Name);
            Assert.AreEqual(-1, person.Turns);  // Should remain -1 (infinite)
            Assert.AreEqual(3, queue.Length);  // Jane should stay in queue

            // Bob's second turn
            person = queue.GetNextPerson();
            Assert.AreEqual("Bob", person.Name);
            Assert.AreEqual(0, person.Turns);  // Still infinite
            Assert.AreEqual(3, queue.Length);  // Bob should stay in queue

            // Sue's second turn
            person = queue.GetNextPerson();
            Assert.AreEqual("Sue", person.Name);
            Assert.AreEqual(1, person.Turns);  // Decreased from 2 to 1
            Assert.AreEqual(3, queue.Length);  // Sue should stay in queue

            // Jane's second turn
            person = queue.GetNextPerson();
            Assert.AreEqual("Jane", person.Name);
            Assert.AreEqual(-1, person.Turns);  // Still infinite
            Assert.AreEqual(3, queue.Length);  // Jane should stay in queue

            // Bob's third turn
            person = queue.GetNextPerson();
            Assert.AreEqual("Bob", person.Name);
            Assert.AreEqual(0, person.Turns);  // Still infinite
            Assert.AreEqual(3, queue.Length);  // Bob should stay in queue

            // Sue's last turn
            person = queue.GetNextPerson();
            Assert.AreEqual("Sue", person.Name);
            Assert.AreEqual(0, person.Turns);  // Decreased from 1 to 0
            Assert.AreEqual(2, queue.Length);  // Sue should be gone now, 2 people left

            // Jane's third turn
            person = queue.GetNextPerson();
            Assert.AreEqual("Jane", person.Name);
            Assert.AreEqual(-1, person.Turns);  // Still infinite
            Assert.AreEqual(2, queue.Length);  // Jane should stay in queue

            // Only Bob and Jane should be left now, alternating
            person = queue.GetNextPerson();
            Assert.AreEqual("Bob", person.Name);
            person = queue.GetNextPerson();
            Assert.AreEqual("Jane", person.Name);
            person = queue.GetNextPerson();
            Assert.AreEqual("Bob", person.Name);
        }
    }
}