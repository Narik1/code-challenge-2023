/*
 * Day 1 • Majority Element
 * 
 * Given an array nums of size n, return the majority element.
 * The majority element is the element that appears more than ⌊n / 2⌋ times. You may assume that the majority element always exists in the array.
 * 
 * Example 1:
 * Input: nums = [3,2,3]
 * Output: 3
 * 
 * Example 2:
 * Input: nums = [2,2,1,1,1,2,2]
 * Output: 2
 * 
 * Constraints:
 * •  n == nums.length
 * •  1 <= n <= 5 * 10^4
 * •  -10^9 <= nums[i] <= 10^9
 * 
 * 
 * Extra: Solve the problem in linear time and in O(1) space
 * 
 */

// This implementation could also be used to find the number with the plurality, i.e., the mode

using System;
using System.Collections.Generic;
using System.Linq;

int MaxElements = 50000;

List<int> numbers = new() {
	3, 1, 1, 3, 1, 5, 2, 1, 6, 9, 8, 1, 1, 2, 1, 1, 1
};

// This is likely space inefficient, but satisfies O(1) space complexity.
// This could be slightly easier to manage, in a sense, if these were arrays of tuples.
// Given that the target number is in the majority, there can be no more than MaxElements/2 unique values.
int[] elementValues = new int[MaxElements / 2];
int[] elementCounts = new int[MaxElements / 2];

int position = -1; // Keep track of how much of the array has been filled

// Figure out what numbers are in the list
foreach (int num in numbers) {
	if (!elementValues.Contains(num)) {
		elementValues[++position] = num;
	}
}

position = -1; // Use this to keep track of what index in the values array corresponds with the index in the counts array

// Get a count of each number that does occur in the list
foreach (int num in elementValues) {
	elementCounts[++position] = numbers.Count(x => x == num);
}

// Find the number that had the highest occurance and get it's position in the array
int result = elementCounts.Max();
position = Array.IndexOf(elementCounts, result);

Console.WriteLine($"The most common number is: {elementValues[position]}; occuring {result} times");