/*
https://leetcode.com/problems/shortest-unsorted-continuous-subarray/
Given an integer array nums, you need to find one continuous subarray that if you only sort this subarray in ascending order, then the whole array will be sorted in ascending order.

Return the shortest such subarray and output its length.

 

Example 1:

Input: nums = [2,6,4,8,10,9,15]
Output: 5
Explanation: You need to sort [6, 4, 8, 10, 9] in ascending order to make the whole array sorted in ascending order.
Example 2:

Input: nums = [1,2,3,4]
Output: 0
Example 3:

Input: nums = [1]
Output: 0
 

Constraints:

1 <= nums.length <= 104
-105 <= nums[i] <= 105
 

Follow up: Can you solve it in O(n) time complexity?
*/

using System;

public class ShortestUnsortedContinousSubArray
{
    //optimal
    public int FindUnsortedSubarray(int[] nums)
    {
        if (nums.Length == 1)
        {
            return 0;
        }

        int min = Int32.MaxValue;
        int max = Int32.MinValue;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < nums[i - 1])
            {
                min = Math.Min(min, nums[i]);
            }
        }

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            if (nums[i] > nums[i + 1])
            {
                max = Math.Max(max, nums[i]);
            }
        }

        if (min == Int32.MaxValue && max == Int32.MinValue)
        {
            return 0;
        }

        int start = 0, end = nums.Length - 1;
        for (; start < nums.Length; start++)
        {
            if (nums[start] > min)
                break;
        }

        for (; end >= 0; end--)
        {
            if (nums[end] < max)
                break;
        }

        return end - start + 1;
    }

    //not optimal
    public int FindTheUnsortedSubarray(int[] nums)
    {
        int[] newNums = (int[])nums.Clone();
        Array.Sort(nums);
        int start = 0, end = nums.Length - 1;
        for (; start < nums.Length; start++)
        {
            if (nums[start] != newNums[start])
            {
                break;
            }
        }

        if (start >= nums.Length - 1)
        {
            return 0;
        }

        for (; end >= 0; end--)
        {
            if (nums[end] != newNums[end])
            {
                break;
            }
        }

        return end - start + 1;
    }
}