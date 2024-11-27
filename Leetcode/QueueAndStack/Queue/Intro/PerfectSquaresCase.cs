
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack.Queue.Intro
{
    public class PerfectSquaresCase 
    {
        public void Case()
        {
            var result_1 = NumSquares(12); // 3
            var result_2 = NumSquares(13); // 2
            var result_3 = NumSquares(777); // ? 3
            var result_4 = NumSquares(10000); // 2
        }

        private bool BFS(Queue<int> queue, int n)
        {
            var fixCount = queue.Count;
            while (queue.Count > 0 && fixCount > 0)
            {
                var summ = queue.Dequeue();
                var i = 1;
                var check = summ + i * i;
                while (check <= n)
                {
                    if (check < n)
                    {
                        queue.Enqueue(check);
                    }
                    else if (check == n)
                    {
                        return true;
                    }
                    i++;
                    check = summ + i * i;
                }
                fixCount--;
            }
            return false;
        }

        public int NumSquares(int n)
        {
            var queue = new Queue<int>();
            queue.Enqueue(0);

            var resultCount = 1;
            while (queue.Count > 0)
            {
                if(BFS(queue, n))
                {
                    return resultCount;
                }
                resultCount++;
            }

            return -1;
        }
    }
}
