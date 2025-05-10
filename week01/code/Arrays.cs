using System;
using System.Collections.Generic;
using System.Diagnostics;

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
            // 1. Handle edge cases
            // 2. Ensure amount is within bounds
            // 3. Use a simple algorithm that leverages GetRange and Clear/AddRange
            
            // Step 1: Handle edge cases
            if (data == null || data.Count <= 1)
            {
                return;  // Nothing to rotate
            }
            
            // Step 2: Ensure amount is within bounds
            // According to the assignment, amount is in range [1, data.Count]
            
            // Step 3: Perform rotation
            // For a right rotation by k, take the last k elements and move them to the front
            int k = amount;
            List<T> rotatedPart = data.GetRange(data.Count - k, k);
            List<T> remainingPart = data.GetRange(0, data.Count - k);
            
            data.Clear();
            data.AddRange(rotatedPart);
            data.AddRange(remainingPart);
        }
    }
}