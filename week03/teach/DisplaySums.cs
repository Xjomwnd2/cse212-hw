using System;
using System.Collections.Generic;

public static class DisplaySums
{
    public static void Run()
    {
        Console.WriteLine("Finding pairs that sum to 10...");
        
        // Test with the example list from the problem description
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        
        Console.WriteLine($"Numbers: [{string.Join(", ", numbers)}]");
        Console.WriteLine("Pairs that sum to 10:");
        
        DisplaySumPairs(numbers);
    }
    
    /// <summary>
    /// Finds and displays all pairs of numbers in a list that sum to 10.
    /// Uses a HashSet for O(n) time complexity and avoids duplicates.
    /// </summary>
    /// <param name="numbers">List of numbers (assumed to have no duplicates)</param>
    public static void DisplaySumPairs(List<int> numbers)
    {
        // HashSet provides O(1) lookup time for checking if a number exists
        HashSet<int> seenNumbers = new HashSet<int>();
        
        bool foundAnyPairs = false;
        
        // Iterate through each number in the list - O(n) operation
        foreach (int currentNumber in numbers)
        {
            // Calculate what number we need to make a sum of 10
            int complement = 10 - currentNumber;
            
            // Check if the complement exists in our set of seen numbers - O(1) operation
            if (seenNumbers.Contains(complement))
            {
                // We found a pair! Display it (smaller number first for consistency)
                int first = Math.Min(currentNumber, complement);
                int second = Math.Max(currentNumber, complement);
                Console.WriteLine($"{first} + {second} = 10");
                foundAnyPairs = true;
            }
            
            // Add the current number to our set for future lookups
            seenNumbers.Add(currentNumber);
        }
        
        if (!foundAnyPairs)
        {
            Console.WriteLine("No pairs found that sum to 10.");
        }
    }
}