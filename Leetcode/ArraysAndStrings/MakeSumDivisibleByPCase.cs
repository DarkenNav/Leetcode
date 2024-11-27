using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    public class MakeSumDivisibleByPCase
    {
        public void Cases()
        {
            // Output: 1
            var result_0 = MinSubarray([3, 1, 4, 2], 6);
            // Output: 2
            var result_1 = MinSubarray([6, 3, 5, 2], 9);
            // Output: 0
            var result_2 = MinSubarray([1, 2, 3], 3);
        }

        public int MinSubarray(int[] nums, int p)
        {
            var n = nums.Length;
            var totalSum = 0;
            foreach (var i in nums)
            {
                totalSum = (totalSum + i) % p;
            }
            var target = totalSum % p;
            if(target == 0)
                return 0;

            var currentSum = 0;
            var map = new Dictionary<int, int>();
            map[0] = -1;
            var result = n;
            for (var i = 0; i < n; i++)
            {
                currentSum = (currentSum + nums[i]) % p;
                var needed = (currentSum - target + p) % p;
                if (map.TryGetValue(needed, out int value))
                {
                    result = Math.Min(result, i - value);                    
                }
                map[currentSum] = i;
            }
            return result == n ? -1 : result;
        }
    }
}
