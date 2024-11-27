
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class LargestNumberAtLeastTwiceofOthersCase 
    {
        public void Case()
        {
            var result1 = DominantIndex(new int[] { 3, 6, 1, 0 });
            var result2 = DominantIndex(new int[] { 1, 2, 3, 4 });
        }

        public int DominantIndex(int[] nums)
        {
            var max = nums.Max();
            var maxIndex = Array.IndexOf(nums, max);
            var numsLength = nums.Length;
            for (var i = 0; i < numsLength; i++)
            {
                if (i != maxIndex && nums[i] * 2 > max)
                {
                    return -1;
                }
            }

            return maxIndex;
        }
    }
}
