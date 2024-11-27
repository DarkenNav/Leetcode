using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    public class SingleNumberCase
    {
        public void Cases()
        {
            var result_0 = SingleNumber([2, 2, 1]);
            var result_1 = SingleNumber([4, 1, 2, 1, 2]);
            var result_2 = SingleNumber([1]);
        }

        public int SingleNumber(int[] nums)
        {
            var xor = 0;
            for(var i = 0; i < nums.Length; i++)
            {
                xor ^= nums[i];
            }

            return xor;
        }
    }
}
