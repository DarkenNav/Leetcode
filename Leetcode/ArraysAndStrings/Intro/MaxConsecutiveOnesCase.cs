
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class MaxConsecutiveOnesCase 
    {
        public void Case()
        {
            var result1 = FindMaxConsecutiveOnes(new int[] { 1, 1, 0, 1, 1, 1 });
            var result2 = FindMaxConsecutiveOnes(new int[] { 1, 0, 1, 1, 0, 1 });
            var result3 = FindMaxConsecutiveOnes(new int[] { 1 });
            var result4 = FindMaxConsecutiveOnes(new int[] { 0 });
        }

        public int FindMaxConsecutiveOnes(int[] nums)
        {
            var numLength = nums.Length;
            var k = 0;
            var kMax = 0;
            for(var i = 0; i < numLength; i++)
            {
                if (nums[i] == 1)
                {
                    k++;
                    if(k > kMax)
                        kMax = k;
                }
                else
                {
                    k = 0;
                }
            }
            return kMax;
        }
    }
}
