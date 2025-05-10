using System;
using System.Collections.Generic;
using System.Diagnostics; // Added for potential debugging

namespace DynamicArrays
{
    public class Arrays
    {
        /// <summary>
        /// Creates and returns an array of multiples of a number.
        /// </summary>
        /// <param name="number">The number to find multiples of</param>
        /// <param name="count">The number of multiples to generate</param>
        /// <returns>An array containing the multiples of number</returns>
        public static double[] MultiplesOf(double number, int count)
        {
            // PLAN:
            // 1. Create a new array to store the multiples - size will be count
            // 2. Loop from 1 to count
            // 3. For each iteration i, calculate number * i and store in array
            // 4. Return the array of multiples
            
            // Step 1: Create a new array of size count to store the multiples
            double[] multiples = new double[count];
            
            // Step 2 & 3: Loop through and calculate each multiple
            for (int i = 0; i < count; i++)
            {
                // Calculate the multiple (number * (i+1)) and store it in the array
                // We use (i+1) because we want multiples starting from 1x, 2x, 3x, etc.
                multiples[i] = number * (i + 1);
            }
            
            // Step 4: Return the array with all multiples
            return multiples;
        }

        /// <summary>
        /// Rotates a list to the right by a specified amount.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list</typeparam>
        /// <param name="data">The list to rotate</param>
        /// <param name="amount">The number of positions to rotate right</param>
        public static void RotateListRight<T>(List<T> data, int amount)
        {
            // PLAN:
            // 1. Check for null or empty list - return if no action needed
            // 2. Create a temporary copy of the list to avoid issues with in-place operations
            // 3. Clear the original list
            // 4. Add elements back in the rotated order:
            //    - Start with elements from (length-amount) to the end
            //    - Then add elements from the beginning to (length-amount)
            
            // Step 1: Check for invalid inputs or no-op cases
            if (data == null || data.Count <= 1)
            {
                // No rotation needed for empty list, single-element list, or null list
                return;
            }
            
            // Per the assignment, amount will be in range [1, data.Count]
            // Let's make sure it's within that range by taking modulo if needed
            if (amount > data.Count)
            {
                amount = amount % data.Count;
                
                // If amount becomes 0 after modulo, it means we're rotating by the full length
                // which is equivalent to rotating by data.Count
                if (amount == 0)
                {
                    amount = data.Count;
                }
            }
            
            // Step 2: Create a temporary copy of the list to work with
            List<T> tempList = new List<T>(data);
            
            // Step 3: Clear the original list to prepare for adding elements in rotated order
            data.Clear();
            
            // Step 4: Add elements back in rotated order
            // First, add elements from (length-amount) to the end of the original list
            for (int i = tempList.Count - amount; i < tempList.Count; i++)
            {
                data.Add(tempList[i]);
            }
            
            // Then, add elements from the beginning to (length-amount) of the original list
            for (int i = 0; i < tempList.Count - amount; i++)
            {
                data.Add(tempList[i]);
            }
        }
    }
}