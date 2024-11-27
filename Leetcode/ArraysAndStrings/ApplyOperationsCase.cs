
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    public class ApplyOperationsCase 
    {
        public void Case()
        {
            var result1 = ApplyOperations(new int[] { 1, 2, 2, 1, 1, 0 });
            var result2 = ApplyOperations(new int[] { 0, 1 });
        }

        public int[] ApplyOperations(int[] nums)
        {
            var lenght = nums.Length;
            for (int i = 0; i < lenght - 1; i++)
            {
                if (nums[i] == nums[i+1])
                {
                    nums[i] = nums[i] * 2;
                    nums[i + 1] = 0;
                }
            }

            var result = new int[lenght];
            var j = 0;
            var k = lenght - 1;

            for (int i = 0; i < lenght || i < k; i++)
            {
                if (nums[i] != 0)
                {
                    result[j] = nums[i];
                    j++;
                }
                else
                {
                    result[k] = 0;
                    k--;
                }
            }

            return result;
        }
    }
}
