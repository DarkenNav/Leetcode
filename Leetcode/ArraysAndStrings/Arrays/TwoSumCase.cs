using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    public class TwoSumCase
    {
        public void Cases()
        {
            // Input: nums = [2,7,11,15], target = 9
            // Output: [0,1]
            var result_0 = TwoSum([2, 7, 11, 15], 9);
        }

        public int[] TwoSum(int[] nums, int target)
        {
            var n = nums.Length;
            var dic = new Dictionary<int, int>();
            for(var i = 0; i < n; i++)
            {
                if (dic.TryGetValue(target - nums[i], out int index))
                    return [index, i];

                dic[nums[i]] = i;
            }
            return [];
        }

        public int[] TwoSum_1(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                        return [i, j];
                }
            }
            return [];
        }
    }
}
