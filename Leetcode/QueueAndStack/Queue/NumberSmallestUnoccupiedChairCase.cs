using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack.Queue
{
    public class NumberSmallestUnoccupiedChairCase
    {
        public void Cases()
        {
            // Output: 1
            var result_0 = SmallestChair([[1, 4], [2, 3], [4, 6]], 1);
            // Output: 2
            var result_1 = SmallestChair([[3, 10], [1, 5], [2, 6]], 0);
        }

        public int SmallestChair(int[][] times, int targetFriend)
        {
            var n = times.Length;
            var sorted = times.OrderBy(x => x[0]).ToArray();
            var targetTime = times[targetFriend];
            var chairs = new int[n];
            for (var i = 0; i < n; i++)
            {                
                for(var j = 0; j < n;  j++)
                {
                    if (chairs[j] == 0 || sorted[i][0] >= chairs[j])
                    {
                        chairs[j] = sorted[i][1];

                        if (Array.Equals(sorted[i], targetTime))
                            return j;

                        break;
                    }                    
                }
            }
            return 0;
        }

    }
}
