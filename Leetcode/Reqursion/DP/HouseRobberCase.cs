using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Reqursion.DP
{
    public class HouseRobberCase
    {
        public void Cases()
        {
            // Output: 4
            var result_0 = Rob([1, 2, 3, 1]);
            // Output: 12
            var result_1 = Rob([2, 7, 9, 3, 1]);
        }

        public int Rob(int[] nums)
        {
            var n = nums.Length;
            if (n == 1)
                return nums[0];

            //var dp = new int[n + 1];
            //dp[0] = 0;
            //dp[1] = nums[0];
            var result = 0;
            var preLast = 0;
            var last = nums[0];

            for (var i = 2; i <= n; i++)
            {
                //dp[i] = Math.Max(nums[i - 1] + dp[i - 2], dp[i - 1]);
                result = Math.Max(nums[i - 1] + preLast, last);
                preLast = last;
                last = result;
            }

            //return dp[n];
            return result;
        }

        // )))
        public int Rob_X(int[] nums)
        {
            var sumF = 0;
            var sumS = 0;
            for(var i = 0; i < nums.Length; i++)
            {
                if(i % 2 == 0)
                    sumF += nums[i];
                else
                    sumS += nums[i];
            }
            return Math.Max(sumF, sumS);
        }
    }
}
