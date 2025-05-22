using System;
using System.Collections.Generic;

public static class DisplaySums
{
    /// <summary>
    /// Finds and displays all pairs of numbers in a list that sum to 10.
    /// Uses a HashSet for O(n) time complexity and avoids duplicates.
    /// </summary>
    /// <param name="numbers">List of numbers (assumed to have no duplicates)</param>
    public static void DisplaySumPairs(List<int> numbers)
    {
        // Create a HashSet to store numbers we've already seen
        HashSet<int> seenNumbers = new HashSet<int>();
        
        Console.WriteLine("Pairs that sum to 10:");
        
        // Iterate through each number in the list
        foreach (int currentNumber in numbers)
        {
            // Calculate what number we need to make a sum of 10
            int complement = 10 - currentNumber;
            
            // Check if the complement exists in our set of seen numbers
            if (seenNumbers.Contains(complement))
            {
                // We found a pair! Display it (smaller number first for consistency)
                int first = Math.Min(currentNumber, complement);
                int second = Math.Max(currentNumber, complement);
                Console.WriteLine($"{first} + {second} = 10");
            }
            
            // Add the current number to our set for future lookups
            seenNumbers.Add(currentNumber);
        }
    }
    
    /// <summary>
    /// Alternative implementation that returns the pairs instead of printing them
    /// </summary>
    /// <param name="numbers">List of numbers (assumed to have no duplicates)</param>
    /// <returns>List of tuples representing pairs that sum to 10</returns>
    public static List<(int, int)> FindSumPairs(List<int> numbers)
    {
        HashSet<int> seenNumbers = new HashSet<int>();
        List<(int, int)> pairs = new List<(int, int)>();
        
        foreach (int currentNumber in numbers)
        {
            int complement = 10 - currentNumber;
            
            if (seenNumbers.Contains(complement))
            {
                // Store pairs with smaller number first for consistency
                int first = Math.Min(currentNumber, complement);
                int second = Math.Max(currentNumber, complement);
                pairs.Add((first, second));
            }
            
            seenNumbers.Add(currentNumber);
        }
        
        return pairs;
    }
}