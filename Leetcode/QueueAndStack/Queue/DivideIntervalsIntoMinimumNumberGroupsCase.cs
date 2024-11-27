using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack.Queue
{
    public class DivideIntervalsIntoMinimumNumberGroupsCase
    {
        public void Cases()
        {
            // Output: 3
            var result_0 = MinGroups([[5, 10], [6, 8], [1, 5], [2, 3], [1, 10]]);
            // Output: 1
            var result_1 = MinGroups([[1, 3], [5, 6], [8, 10], [11, 13]]);
            // Output: 4
            var result_2 = MinGroups([[441459, 446342], [801308, 840640], [871890, 963447], [228525, 336985], [807945, 946787], [479815, 507766], [693292, 944029], [751962, 821744]]);
        }

        // Подход 3: Алгоритм линейной развертки без упорядоченного контейнера
        public int MinGroups(int[][] intervals)
        {
            var rangeStart = int.MaxValue;
            var rangeEnd = int.MinValue;
            foreach (var item in intervals)
            {
                rangeStart = Math.Min(rangeStart, item[0]);
                rangeEnd = Math.Max(rangeEnd, item[1]);
            }
  
            var pointToCount = new int[rangeEnd + 2];
            foreach (var item in intervals)
            {
                pointToCount[item[0]]++;
                pointToCount[item[1] + 1]--;
            }

            var concurrentIntervals = 0;
            var maxConcurrentIntervals = 0;
            for (var i = rangeStart; i <= rangeEnd; i++)
            {
                concurrentIntervals += pointToCount[i];
                maxConcurrentIntervals = Math.Max(maxConcurrentIntervals, concurrentIntervals);
            }

            return maxConcurrentIntervals;
        }

        // Подход 1: Сортировка или приоритетная очередь
        public int MinGroups_2(int[][] intervals)
        {
            var n = intervals.Length;
            var events = new List<int[]>();
            foreach(var item in intervals)
            {
                events.Add([item[0], 1]);
                events.Add([item[1] + 1, -1]);
            }
            events.Sort((a, b) =>
            {
                if (a[0] == b[0])
                    return a[1].CompareTo(b[1]);
                return a[0].CompareTo(b[0]); 
            });

            var concurrentIntervals = 0;
            var maxConcurrentIntervals = 0;
            foreach (var item in events)
            {
                concurrentIntervals += item[1];
                maxConcurrentIntervals = Math.Max(maxConcurrentIntervals, concurrentIntervals);
            }

            return maxConcurrentIntervals;
        }

        // -- wrong
        public int MinGroups_1(int[][] intervals)
        {
            var n = intervals.Length;
            var intersectionCount = 0;
            var intersections = new int[n];
            for (var i = 0; i < n; i++)
            {
                if (intersections[i] == 0)
                {
                    intersections[i] = i + 1;
                    for (var j = i + 1; j < n; j++)
                    {
                        if (intersections[j] == 0 
                            && Intersection(intervals[i], intervals[j]))
                        {
                            intersectionCount++;
                            intersections[j] = i + 1;
                        }
                    }                    
                }
            }

            return intersectionCount;
        }

        private bool Intersection(int[] a, int[] b)
        {
            return a[0] <= b[1] && a[1] >= b[0];
        }
    }
}
