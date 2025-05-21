using System;
using System.Collections.Generic;

public class DisplaySums
{
    public static void DisplaySumPairs(List<int> numbers)
    {
        // Create a set to store numbers we've seen so far
        HashSet<int> seenNumbers = new HashSet<int>();
        
        // Loop through each number in the list
        foreach (var number in numbers)
        {
            // Calculate the complement of the current number
            int complement = 10 - number;
            
            // If the complement is already in the set, we found a pair
            if (seenNumbers.Contains(complement))
            {
                Console.WriteLine($"Pair found: ({complement}, {number})");
            }
            
            // Add the current number to the set
            seenNumbers.Add(number);
        }
    }
}
