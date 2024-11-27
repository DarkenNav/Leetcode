using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch.Conclusion
{
    public class FindDuplicateNumberCase
    {
        public void Cases()
        {
            // 2
            var result_0 = FindDuplicate([1, 3, 4, 2, 2]);
            // 3
            var result_1 = FindDuplicate([3, 1, 3, 4, 2]);
            // 3
            var result_2 = FindDuplicate([3, 3, 3, 3, 3]);
        }

        // 1 <= nums[i] <= n
        public int FindDuplicate(int[] nums)
        {
            var n = nums.Length;
            var counts = new int[n];
            var i = 0;
            while (i < n)
            {
                counts[nums[i]]++;
                if (counts[nums[i]] > 1)
                    break;
                
                i++;
            }
            return nums[i];
        }
    }
}
