using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Test case 1: Numbers from 1 to 10
        Console.WriteLine("Test 1: Numbers 1-10");
        List<int> numbers1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        DisplaySums.DisplaySumPairs(numbers1);
        Console.WriteLine();
        
        // Test case 2: Random numbers
        Console.WriteLine("Test 2: Random numbers");
        List<int> numbers2 = new List<int> { 2, 7, 11, 15, 3, 6, 4, 8, 1, 9 };
        DisplaySums.DisplaySumPairs(numbers2);
        Console.WriteLine();
        
        // Test case 3: No pairs sum to 10
        Console.WriteLine("Test 3: No pairs sum to 10");
        List<int> numbers3 = new List<int> { 1, 2, 3, 11, 12, 13 };
        DisplaySums.DisplaySumPairs(numbers3);
        Console.WriteLine();
        
        // Test case 4: Using the alternative method that returns pairs
        Console.WriteLine("Test 4: Using FindSumPairs method");
        var pairs = DisplaySums.FindSumPairs(numbers1);
        Console.WriteLine($"Found {pairs.Count} pairs:");
        foreach (var pair in pairs)
        {
            Console.WriteLine($"{pair.Item1} + {pair.Item2} = 10");
        }
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}