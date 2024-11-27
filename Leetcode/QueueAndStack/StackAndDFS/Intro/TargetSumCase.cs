
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack.StackAndDFS.Intro
{
    public class TargetSumCase 
    {
        public void Case()
        {
            // 5
            var result_0 = FindTargetSumWays(new int[] { 1, 1, 1, 1, 1 }, 3);
            // 1
            var result_1 = FindTargetSumWays(new int[] { 1 }, 1);

            var result_2 = FindTargetSumWays(new int[] { 1, 2, 3, 4, 5 }, 0);

            var result_3 = FindTargetSumWays(new int[] { 1, 2, 3, 1, 5 }, 0);

        }

        public int FindTargetSumWays(int[] nums, int target)
        {
            var count = 0;
            var stack = new Stack<(int index, int value)>();
            stack.Push((0, nums[0]));
            stack.Push((0, -nums[0]));
            var length = nums.Length;
            while (stack.Count > 0)
            {
                var summ = stack.Pop();
                if(summ.index + 1 < length)
                {
                    stack.Push((summ.index + 1, summ.value + nums[summ.index + 1]));
                    stack.Push((summ.index + 1, summ.value - nums[summ.index + 1]));
                }
                else if (summ.value == target)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
