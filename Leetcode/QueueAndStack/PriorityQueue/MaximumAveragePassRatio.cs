using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack.PriorityQueue
{
    /// <summary>
    /// 1792. Maximum Average Pass Ratio
    /// </summary>
    public class MaximumAveragePassRatio
    {
        public void Cases()
        {
            // Output: 0.78333
            var result_0 = MaxAverageRatio([[1,2],[3,5],[2,2]], 2);
            // Output: 0.53485
            var result_1 = MaxAverageRatio([[2,4],[3,9],[4,5],[2,10]], 4);
        }

        public double MaxAverageRatio(int[][] classes, int extraStudents)
        {
            var pq = new PriorityQueue<int, double>();
            for(var i = 0; i < classes.Length; i++)
            {
                var divRatio = (double)classes[i][0] / classes[i][1] - 
                    (double)(classes[i][0] + 1) / (classes[i][1] + 1);
                pq.Enqueue(i, divRatio);
            }

            while(pq.Count > 0 && extraStudents > 0)
            {
                var i = pq.Dequeue();
                classes[i][0]++;
                classes[i][1]++;
                var divRatio = (double)classes[i][0] / classes[i][1] - 
                    (double)(classes[i][0] + 1) / (classes[i][1] + 1);
                pq.Enqueue(i, divRatio);
                extraStudents--;
            }

            double sum = 0;
            foreach(var cl in classes)
                sum += (double)cl[0] / cl[1];

            return Math.Round(sum / classes.Length, 5) ;
        }
    }
}