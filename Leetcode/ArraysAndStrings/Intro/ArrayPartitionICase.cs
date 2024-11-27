
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class ArrayPartitionICase 
    {
        public void Case()
        {
            var result1 = ArrayPairSum(new int[] { 1, 4, 3, 2 });
            var result2 = ArrayPairSum(new int[] { 6, 2, 6, 5, 1, 2 });
        }

        public int ArrayPairSum(int[] nums)
        {
            var numsSort = nums.Order().ToArray();
            var numLength = nums.Length;

            var sum = 0;
            for ( var i = 0; i < numLength - 1; i += 2)
            {
                sum += Math.Min(numsSort[i], numsSort[i + 1]);
            }
            return sum;
        }
    }
}
