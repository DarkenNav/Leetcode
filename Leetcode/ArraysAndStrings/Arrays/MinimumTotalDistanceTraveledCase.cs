using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    // 2463. Minimum Total Distance Traveled
    internal class MinimumTotalDistanceTraveledCase
    {
        internal void Cases()
        {
            var result = MinimumTotalDistance([0, 4, 6, 1, 2], [[2, 2], [6, 2], [-1, 2]]);
        }

        public long MinimumTotalDistance(IList<int> robot, int[][] factory)
        {
            var robots = robot.Order().ToArray();
            Array.Sort(factory, (a, b) => a[0].CompareTo(b[0]));

            var factoryPositions = new List<int>();
            foreach(var f in factory)
            {
                for(var i = 0; i < f[1]; i++)
                {
                    factoryPositions.Add(f[0]);
                }
            }

            var robotsCount = robots.Count();
            var factoryCount = factoryPositions.Count;

            long[][] dp = new long[robotsCount + 1][];
            for (var i = 0; i < robotsCount + 1; i++)
            {
                dp[i] = new long[factoryCount + 1];
                if(i < robotsCount)
                    dp[i][factoryCount] = (long)1e12;
            }

            for(var i = robotsCount - 1; i >= 0; i--)
            {
                for (var j = factoryCount - 1; j >= 0; j--)
                {
                    var assign = Math.Abs(robots[i] - factoryPositions[j]) + dp[i + 1][j + 1];
                    var skip = dp[i][j + 1];
                    dp[i][j] = Math.Min(assign, skip);
                }
            }

            return dp[0][0];
        }
    }
}
