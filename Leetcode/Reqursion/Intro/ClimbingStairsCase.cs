using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Reqursion.Intro
{
    public class ClimbingStairsCase
    {
        public void Cases()
        {
            //var result_0 = ClimbStairs(2);

            //var result_1 = ClimbStairs(3);

            var result_45 = ClimbStairs_1(45);
            var result_45_0 = ClimbStairs(45);
        }

        public int ClimbStairs(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;

            var map = new int[n + 1];
            map[1] = 1;
            map[2] = 2;
            for(var i = 3; i <= n; i++)
            {
                map[i] = map[i - 1] + map[i - 2];
            }

            return map[n];
        }

        // Reqursion and memo
        private Dictionary<int, int> memo = new Dictionary<int, int>();
        public int ClimbStairs_1(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;

            if (!memo.ContainsKey(n - 1))
                memo.Add(n - 1, ClimbStairs_1(n - 1));
            if (!memo.ContainsKey(n - 2))
                memo.Add(n - 2, ClimbStairs_1(n - 2));

            return memo[n-1] + memo[n-2];
        }
    }
}
