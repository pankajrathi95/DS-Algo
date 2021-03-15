/*
https://leetcode.com/problems/restore-the-array-from-adjacent-pairs/

There is an integer array nums that consists of n unique elements, but you have forgotten it. However, you do remember every pair of adjacent elements in nums.

You are given a 2D integer array adjacentPairs of size n - 1 where each adjacentPairs[i] = [ui, vi] indicates that the elements ui and vi are adjacent in nums.

It is guaranteed that every adjacent pair of elements nums[i] and nums[i+1] will exist in adjacentPairs, either as [nums[i], nums[i+1]] or [nums[i+1], nums[i]]. The pairs can appear in any order.

Return the original array nums. If there are multiple solutions, return any of them.

 

Example 1:

Input: adjacentPairs = [[2,1],[3,4],[3,2]]
Output: [1,2,3,4]
Explanation: This array has all its adjacent pairs in adjacentPairs.
Notice that adjacentPairs[i] may not be in left-to-right order.
Example 2:

Input: adjacentPairs = [[4,-2],[1,4],[-3,1]]
Output: [-2,4,1,-3]
Explanation: There can be negative numbers.
Another solution is [-3,1,4,-2], which would also be accepted.
Example 3:

Input: adjacentPairs = [[100000,-100000]]
Output: [100000,-100000]
 

Constraints:

nums.length == n
adjacentPairs.length == n - 1
adjacentPairs[i].length == 2
2 <= n <= 105
-105 <= nums[i], ui, vi <= 105
There exists some nums that has adjacentPairs as its pairs.
*/

using System.Collections.Generic;

public class RestoretheArrayFromAdjacentPairs
{
    public int[] RestoreArray(int[][] adjacentPairs)
    {
        Dictionary<int, IList<int>> values = new Dictionary<int, IList<int>>();
        foreach (var adjacentPair in adjacentPairs)
        {
            if (!values.ContainsKey(adjacentPair[0]))
            {
                values.Add(adjacentPair[0], new List<int>());
            }

            if (!values.ContainsKey(adjacentPair[1]))
            {
                values.Add(adjacentPair[1], new List<int>());
            }

            values[adjacentPair[0]].Add(adjacentPair[1]);
            values[adjacentPair[1]].Add(adjacentPair[0]);
        }

        int start = 0;
        foreach (var kvp in values)
        {
            if (kvp.Value.Count == 1)
            {
                start = kvp.Key;
                break;
            }
        }

        int[] result = new int[values.Count];
        result[0] = start;
        HashSet<int> seen = new HashSet<int>();
        seen.Add(result[0]);
        for (int i = 1; i < values.Count; i++)
        {
            foreach (var item in values[result[i - 1]])
            {
                if (!seen.Contains(item))
                {
                    seen.Add(item);
                    result[i] = item;
                    break;
                }
            }
        }

        return result;
    }
}