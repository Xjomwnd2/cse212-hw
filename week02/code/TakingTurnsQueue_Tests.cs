using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; private set; }
    public int Turns { get; internal set; }

    public Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }
}

public class TakingTurnsQueue
{
    private Queue<Person> queue = new Queue<Person>();

    public int Length => queue.Count;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        queue.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (queue.Count == 0)
            throw new InvalidOperationException("No one in the queue.");

        var person = queue.Dequeue();

        // Create a returnable reference before modifying
        var returnPerson = new Person(person.Name, person.Turns);

        // Handle infinite turns: 0 or negative
        bool hasInfiniteTurns = person.Turns <= 0;

        if (!hasInfiniteTurns)
        {
            person.Turns--;
        }

        if (hasInfiniteTurns || person.Turns > 0)
        {
            queue.Enqueue(person); // Only requeue if they have more turns or infinite turns
        }

        return returnPerson;
    }
}
