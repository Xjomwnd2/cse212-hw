public class Person
{
    public string Name { get; private set; }
    public int Turns { get; private set; }

    public Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }

    public void UseTurn()
    {
        if (Turns > 0)
        {
            Turns--;
        }
    }

    public bool HasInfiniteTurns()
    {
        return Turns <= 0;
    }
}

public class TakingTurnsQueue
{
    private Queue<Person> queue = new Queue<Person>();

    public int Length => queue.Count;

    public void AddPerson(string name, int turns)
    {
        queue.Enqueue(new Person(name, turns));
    }

    public Person GetNextPerson()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person current = queue.Dequeue();
        Person returnPerson = new Person(current.Name, current.Turns); // Return a copy to preserve turn state in tests

        current.UseTurn();

        // Only re-add if infinite turns or still has turns left
        if (current.HasInfiniteTurns() || current.Turns > 0)
        {
            queue.Enqueue(current);
        }

        return returnPerson;
    }
}
