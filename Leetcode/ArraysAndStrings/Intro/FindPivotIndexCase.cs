
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class FindPivotIndexCase 
    {
        public void Case()
        {
            var result1 = PivotIndex(new int[] { 1, 7, 3, 6, 5, 6 });
            var result2 = PivotIndex(new int[] { 1, 2, 3 });
            var result3 = PivotIndex(new int[] { 2, 1, -1 });
            var result4 = PivotIndex(new int[] { -1, -1, 0, 1, 1, 0 });
            var result5 = PivotIndex(new int[] { -1, -1, 1, 1, 0, 0 });
        }


        public int PivotIndex(int[] nums)
        {
            var numsLength = nums.Length;
            if (nums[1..numsLength].Sum() == 0)
                return 0;

            for (int i = 1; i < numsLength - 1; i++)
            {
                var leftSum = nums[0..i].Sum();
                var rightSum = nums[(i + 1)..numsLength].Sum();
                if (leftSum == rightSum)
                    return i;
            }

            if (nums[0..(numsLength - 1)].Sum() == 0)
                return numsLength - 1;

            return -1;
        }
    }
}
