/*
Given a 32-bit signed integer, reverse digits of an integer.

Example 1:

Input: 123
Output: 321
Example 2:

Input: -123
Output: -321
Example 3:

Input: 120
Output: 21
Note:
Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.
*/

using System;

public class ReverseInteger
{
    public int Reverse(int x)
    {
        if (x % 10 == x)
        {
            return x;
        }

        long rev = 0;
        while (x != 0)
        {
            int number = x % 10;
            x /= 10;

            rev = rev * 10 + number;
        }

        if (rev > (long)int.MaxValue || rev < (long)int.MinValue)
        {
            return 0;
        }

        return (int)rev;
    }
}