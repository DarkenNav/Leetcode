using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    // 539. Minimum Time Difference
    public class MinimumTimeDifferenceCase
    {
        public void Cases()
        {
            //// 1
            //var result_0 = FindMinDifference(["23:59", "00:00"]);
            //// 0
            //var result_1 = FindMinDifference(["00:00", "23:59", "00:00"]);
        }

        public int FindMinDifference(IList<string> timePoints)
        {
            var minutesSorted = new int[timePoints.Count];
            var frequency = new int[24 * 60];
            for (var i = 0; i < timePoints.Count; i++)
            {
                var arr = timePoints[i].Split(':');
                var minute = int.Parse(arr[0]) * 60 + int.Parse(arr[1]);
                frequency[minute]++;
            }
            var j = 0;
            for(var i = 0; i < frequency.Length;i++)
            {
                for(var f = 0; f < frequency[i]; f++)
                {
                    minutesSorted[j] = i;
                    j++;
                }
            }

            var minDiff = int.MaxValue;
            var diff = 0;
            for (var i = 0; i < minutesSorted.Length - 1; i++)
            {
                diff = minutesSorted[i+1] - minutesSorted[i];
                if(diff < minDiff)
                    minDiff = diff;
            }

            diff = 24 * 60 - minutesSorted.Last() + minutesSorted.First();
            if (diff < minDiff)
                minDiff = diff;

            return minDiff;
        }
    }
}
