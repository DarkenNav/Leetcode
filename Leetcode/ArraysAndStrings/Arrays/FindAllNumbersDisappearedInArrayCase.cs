using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    public class FindAllNumbersDisappearedInArrayCase
    {
        public void Cases()
        {
            // Output: [5,6]
            var result_0 = FindDisappearedNumbers([4, 3, 2, 7, 8, 2, 3, 1]);
            // Output: [2]
            var result_1 = FindDisappearedNumbers([1, 1]);
        }

        // n == nums.length
        // 1 <= n <= 10^5
        // 1 <= nums[i] <= n
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            var n = nums.Length;
            for (int i = 0; i < n; i++) 
            {
                var index = Math.Abs(nums[i]) - 1;
                if (nums[index] > 0)
                    nums[index] *= -1;
            }

            var list = new List<int>();
            for(var i = 0; i < n; i++)
            {
                if (nums[i] > 0)
                    list.Add(i + 1);
            }

            return list;
        }
    }
}
