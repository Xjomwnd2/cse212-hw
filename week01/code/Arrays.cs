using System;
using System.Collections.Generic;

public class Arrays
{
    // Part 1: MultiplesOf Function
    // This function takes a starting number and a count of how many multiples to generate.
    // For example, MultiplesOf(3, 5) returns [3, 6, 9, 12, 15].

    public static double[] MultiplesOf(double start, int count)
    {
        // Step 1: Create a new array with the size equal to count
        double[] result = new double[count];

        // Step 2: Use a loop to fill in the array with multiples of the start number
        for (int i = 0; i < count; i++)
        {
            result[i] = start * (i + 1);
        }

        // Step 3: Return the result array
        return result;
    }

    // Part 2: RotateListRight Function
    // This function takes a list of integers and rotates the list to the right by a given amount.
    // Example: RotateListRight([1,2,3,4,5,6,7,8,9], 5) returns [5,6,7,8,9,1,2,3,4]

    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Calculate how many elements will be rotated from the end to the beginning
        int cutIndex = data.Count - amount;

        // Step 2: Create two slices: tail and head
        List<int> tail = data.GetRange(cutIndex, amount);
        List<int> head = data.GetRange(0, cutIndex);

        // Step 3: Clear the original list and add the new order
        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
