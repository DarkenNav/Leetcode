using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack.Stack
{
    // 962. Maximum Width Ramp
    public class MaximumWidthRampCase
    {
        public void Cases()
        {
            // Output: 4
            var result_0 = MaxWidthRamp([6, 0, 8, 2, 1, 5]);
            // Output: 7
            var result_1 = MaxWidthRamp([9, 8, 1, 0, 1, 9, 4, 0, 4, 1]);
        }

        // Stack
        public int MaxWidthRamp(int[] nums)
        {
            var n = nums.Length;
            var stack = new Stack<int>();
            stack.Push(0);
            for (var i = 1; i < n; i++)
            {
                if (nums[stack.Peek()] > nums[i])
                    stack.Push(i);
            }

            var max = 0;
            for(var i = n - 1; i >= 0; i-- )
            {
                while(stack.Count > 0 && nums[stack.Peek()] <= nums[i])
                {
                    var index = stack.Pop();
                    max = Math.Max(max, i - index);
                }
            }

            return max;
        }

        // Cicle
        public int MaxWidthRamp_1(int[] nums)
        {
            var n = nums.Length;
            int max = 0;
            for(var i = 0; i < n; i++)
            {
                for(var j = i + 1; j < n; j++)
                {
                    if (nums[i] <= nums[j]) 
                    {
                        max = Math.Max(max, j - i);
                    }
                }
            }
            return max;
        }
    }
}
