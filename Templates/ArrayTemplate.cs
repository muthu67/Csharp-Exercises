using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetDSAPatterns.Templates
{
    /// <summary>
    /// Array Template for solving array-related DSA problems
    /// </summary>
    public class ArrayTemplate
    {
        /// <summary>
        /// Template method for solving array problems
        /// </summary>
        public void SolveArrayProblem(int[] nums)
        {
            // Step 1: Understand the problem
            // - Input: array of integers
            // - Output: solution based on problem requirements
            
            // Step 2: Edge cases
            if (nums == null || nums.Length == 0)
            {
                return;
            }
            
            // Step 3: Approach
            // Consider: Brute force, Optimized solution, Space complexity
            
            // Step 4: Implementation
            // Your solution here
            
            // Step 5: Testing
            // Test with edge cases, normal cases, large inputs
        }
        
        /// <summary>
        /// Common helper methods for array operations
        /// </summary>
        
        // Swap elements
        private void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        
        // Reverse array
        private void Reverse(int[] arr)
        {
            int left = 0, right = arr.Length - 1;
            while (left < right)
            {
                Swap(arr, left, right);
                left++;
                right--;
            }
        }
        
        // Check if array is sorted
        private bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                    return false;
            }
            return true;
        }
    }
}
