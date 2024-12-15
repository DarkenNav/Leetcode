using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.ArraysAndStrings.Arrays
{
    /// <summary>
    /// 2593. Find Score of an Array After Marking All Elements
    /// </summary>
    public class FindScoreArrayAfterMarkingAllElementsCase
        : IHeapLC, ISimulationLC, IArrayLC, ISortingLC
    {
        public void Cases()
        {
            // Output: 7
            var result_0 = FindScore([2,1,3,4,5,2]);
            // Output: 5
            var result_1 = FindScore([2,3,5,1,3,2]);

            // Output: 21
            var result_2 = FindScore([4,4,6,6,2,2,9]);
        }

        private class ScorePriority
        {
            public int Index {get; set;}
            public int Value {get; set;}

            public ScorePriority(int i, int val)
            {
                Index = i;
                Value = val;
            }
        }

        private class ComparerByValAndIndex : IComparer<ScorePriority>
        {
            public int Compare(ScorePriority p1, ScorePriority p2)
            {
                if(p1.Value == p2.Value)
                {
                    if(p1.Index == p2.Index)
                        return 0;
                    else if(p1.Index > p2.Index)
                        return 1;
                    else
                        return -1;
                }
                else if(p1.Value > p2.Value)
                    return 1;
                else
                    return -1;
            }
        }

        public long FindScore(int[] nums)
        {
            var n = nums.Length;
            var marks = new bool[n];
            var pq = new PriorityQueue<int, ScorePriority>(
                new ComparerByValAndIndex());

            for(var i = 0; i < n; i++)
                pq.Enqueue(i, new ScorePriority(i, nums[i]));

            long sum = 0;
            while(pq.Count > 0)
            {
                _ = pq.TryDequeue(out int i, out ScorePriority p);
                if(marks[i]) continue;

                marks[i] = true;
                sum += p.Value;
                if(i > 0)
                    marks[i-1] = true;
                if(i < n - 1)
                    marks[i+1] = true;
            }

            return sum;
        }
    }
}