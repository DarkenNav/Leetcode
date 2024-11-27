
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class RemoveElementCase 
    {
        public void Case()
        {
            var result1 = RemoveElement(
                new int[] { 3, 2, 2, 3 },
                3
                );
            var result2 = RemoveElement(
                new int[] { 0, 1, 2, 2, 3, 0, 4, 2 },
                2
                );
            var result3 = RemoveElement(
                new int[] { 2, 2, 2, 2 },
                2
                );
            var result4 = RemoveElement(
                new int[] { 3, 3, 3, 3 },
                2
                );
            var result5 = RemoveElement(
                new int[] { 4, 5 },
                5
                );
        }

        public int RemoveElement(int[] nums, int val)
        {
            var i = 0;
            var length = nums.Length;
            var j = length - 1;
            while ( i <= j )
            {
                if (nums[i] == val)
                {
                    if (i != j)
                    {
                        var temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                    j--;
                }
                else 
                { 
                    i++; 
                }
            }
            return j + 1;
        }
    }
}
