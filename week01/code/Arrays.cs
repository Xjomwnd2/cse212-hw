using System;
using System.Collections.Generic;

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
            // 1. Validate inputs - ensure data is not null and amount is valid
            // 2. Handle the case where no rotation is needed
            // 3. Split the list into two parts:
            //    - The part that needs to move from the end to the beginning
            //    - The part that will remain at the beginning but shift right
            // 4. Create new list with parts in correct order
            // 5. Update the original list with the rotated elements
            
            // Step 1: Validate inputs
            if (data == null || data.Count <= 1 || amount <= 0 || amount >= data.Count)
            {
                // No rotation needed or invalid inputs
                return;
            }
            
            // Step 2: Calculate the split point
            // All elements from this index to the end will move to the front
            int splitIndex = data.Count - amount;
            
            // Step 3 & 4: Get the two parts and create a new rotated list
            // Get elements that will move from end to beginning
            List<T> endPart = data.GetRange(splitIndex, amount);
            
            // Get elements that will shift to the right
            List<T> beginPart = data.GetRange(0, splitIndex);
            
            // Step 5: Clear the original list and add the parts in the correct order
            data.Clear();
            data.AddRange(endPart);  // Add the end part first (now at the beginning)
            data.AddRange(beginPart); // Add the begin part after
        }
    }
}