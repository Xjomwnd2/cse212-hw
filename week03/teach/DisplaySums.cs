using System;
using System.Collections.Generic;

public class DisplaySums
{
    public static void DisplaySumPairs(List<int> numbers)
    {
        HashSet<int> seen = new HashSet<int>();
        HashSet<string> printedPairs = new HashSet<string>(); // To prevent duplicates

        foreach (int number in numbers)
        {
            int complement = 10 - number;

            if (seen.Contains(complement))
            {
                int min = Math.Min(number, complement);
                int max = Math.Max(number, complement);
                string pairKey = $"{min},{max}";

                if (!printedPairs.Contains(pairKey))
                {
                    Console.WriteLine($"Pair found: ({min}, {max})");
                    printedPairs.Add(pairKey);
                }
            }

            seen.Add(number);
        }
    }
}
