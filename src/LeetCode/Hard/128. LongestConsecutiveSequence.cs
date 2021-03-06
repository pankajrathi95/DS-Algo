/*
https://leetcode.com/problems/longest-consecutive-sequence/
Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.

 

Example 1:

Input: nums = [100,4,200,1,3,2]
Output: 4
Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
Example 2:

Input: nums = [0,3,7,2,5,8,4,6,0,1]
Output: 9
 

Constraints:

0 <= nums.length <= 104
-109 <= nums[i] <= 109
 

Follow up: Could you implement the O(n) solution?
*/

using System;
using System.Collections.Generic;

public class LongestConsecutiveSequence
{
    //O(n) Solution
    public int LongestConsecutive(int[] nums)
    {
        HashSet<int> values = new HashSet<int>();
        foreach (var num in nums)
        {
            if (!values.Contains(num))
            {
                values.Add(num);
            }
        }

        int result = 0;
        foreach (var num in nums)
        {
            if (!values.Contains(num - 1))
            {
                int currentNum = num;
                int max = 1;

                while (values.Contains(currentNum + 1))
                {
                    max++;
                    currentNum++;
                }

                result = Math.Max(max, result);
            }
        }
        return result;
    }

    //O(nlogn) solution
    public int LongestConsecutivee(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        Array.Sort(nums);
        int max = 1, result = 1;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] == nums[i + 1])
                continue;
            if (nums[i] + 1 == nums[i + 1])
            {
                max++;
            }
            else
            {
                max = 1;
            }

            result = Math.Max(result, max);
        }

        return result;
    }
}