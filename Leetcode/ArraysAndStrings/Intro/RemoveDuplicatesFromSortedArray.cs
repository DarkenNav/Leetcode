
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class RemoveDuplicatesFromSortedArray 
    {
        public void Cases()
        {
            // Output: 2, nums = [1,2,_]
            var result1 = RemoveDuplicates(new int[] { 1, 1, 2 });
            // Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
            var result2 = RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 });
            // // Output: 1, nums = [1,_]
            var result3 = RemoveDuplicates(new int[] { 1, 1 });
        }

        public int RemoveDuplicates(int[] nums)
        {
            var n = nums.Length;
            var position = 0;
            var doublesCount = 0;
            for(var i = 1; i < n; i++)
            {
                if (nums[position] != nums[i])
                {
                    position++;
                    nums[position] = nums[i];
                }
                else
                {
                    doublesCount++;
                }
            }
            return n - doublesCount;
        }
    }
}
