/*
 * DAY 1  •  4 SUM
 * Given an array nums of n integers, return an array of all the
 * unique quadruplets [nums[a], nums[b], nums[c], nums[d]] such that:
 * •  0 <= a, b, c, d < n
 * •  a, b, c, and d are distinct.
 * •  nums[a] +nums[b] + nums[c] + nums[d] == target
 * 
 * You may return the answer in any order.
 * 
 * Example 1:
 * Input: nums = [1, 0, -1, 0, -2, 2], target = 0
 * Output:[[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]
 * 
 * Example 2:
 * Input: nums = [2, 2, 2, 2, 2], target = 8
 * Output:[[2,2,2,2]]
 * 
 * Constraints:
 * •  1 <= nums.length <= 200
 * •  -10 ^ 9 <= nums[i] <= 10 ^ 9
 * •  -10 ^ 9 <= target <= 10 ^ 9
 */

using System;
using System.Collections.Generic;

// Hope you're not a never-nester!
static List<(int, int, int, int)> GetSumationQuadruplets(IList<int> numbers, int targetValue) {
	List<(int, int, int, int)> quads = new();

	for (int i = 0; i < numbers.Count - 3; i++) {
		for (int j = i + 1; j < numbers.Count - 2; j++) {
			for (int k = j + 1; k < numbers.Count - 1; k++) {
				for (int l = k + 1; l < numbers.Count; l++) {
					int sum = numbers[i] + numbers[j] + numbers[k] + numbers[l];
					if (sum == targetValue) {
						var potentialQuad = (numbers[i], numbers[j], numbers[k], numbers[l]);
						if (!quads.Contains(potentialQuad)) {
							quads.Add(potentialQuad);
						}
					}
				}
			}
		}
	}

	return quads;
}

int[] exampleNums1 = { 1, 0, -1, 0, -2, 2 };
int exampleTarget1 = 0;
int[] exampleNums2 = { 2, 2, 2, 2, 2 };
int exampleTarget2 = 8;

var quads = GetSumationQuadruplets(exampleNums1, exampleTarget1);

Console.Write('[');
for (int i = 0; i < quads.Count; i++) {
	var quad = quads[i];

	Console.Write($"[{quad.Item1},{quad.Item2},{quad.Item3},{quad.Item4}]");
	if (i != quads.Count - 1) {
		Console.Write(", ");
	}
}
Console.WriteLine(']');