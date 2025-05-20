using System;

/// <summary>
/// This queue is circular. When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules). When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue. Thus,
/// each person stays in the queue and is given turns. When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given. If the turns is 0 or
/// less than they will stay in the queue forever. If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left. Note that a turns value of 0 or less means the 
    /// person has an infinite number of turns. An error exception is thrown 
    /// if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }
        else
        {
            Person person = _people.Dequeue();

            // If turns is 0 or less, it means infinite turns
            if (person.Turns <= 0)
            {
                // Re-add with same turns value (keep it infinite)
                _people.Enqueue(new Person(person.Name, person.Turns));
            }
            // If turns is greater than 0, decrement and re-add if still has turns
            else
            {
                person.Turns -= 1;
                // Re-add only if they still have turns left (must be 0 or greater)
                if (person.Turns > 0)
                {
                    _people.Enqueue(new Person(person.Name, person.Turns));
                }
            }

            return person;
        }
    }
}