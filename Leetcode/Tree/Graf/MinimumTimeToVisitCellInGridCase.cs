using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.Tree.Graf
{
    /// <summary>
    /// 2577. Minimum Time to Visit a Cell In a Grid
    /// </summary>
    public class MinimumTimeToVisitCellInGridCase
         : IArrayLC, IBreadthFirstLC, IGrafLC, IHeapLC, IPriorityQueueLC, IMatrixLC, IShortestPathLC
    {
        internal void Cases()
        {
            // Output: 7
            var result_0 = MinimumTime([[0,1,3,2],[5,1,2,5],[4,3,8,6]]);
            // Output: -1
            var result_1 = MinimumTime([[0,2,4],[3,2,1],[1,0,4]]);
        }

        public int MinimumTime(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            if (grid[0][1] > 1 && grid[1][0] > 1) {
                return -1;
            }

            int[][] directions = [[0,1],[0,-1,],[1,0],[-1,0]];
            var visits = new bool[m][];
            for(var i = 0; i < m; i++)
                visits[i] = new bool[n];

            var pq = new PriorityQueue<(int row, int col), int>();
            pq.Enqueue((0,0), 0);
            while(pq.Count > 0)
            {
                _ = pq.TryDequeue(out var current, out int timeLeft);

                if(current.row == m - 1 && current.col == n - 1)
                    return timeLeft;
                
                if(visits[current.row][current.col])
                    continue;
                visits[current.row][current.col] = true;

                foreach(var dir in directions)
                {
                    var newRow = current.row + dir[0];
                    var newCol = current.col + dir[1];
                    if(newRow >= 0 && newRow < m 
                        && newCol >= 0 && newCol < n
                        && !visits[newRow][newCol])
                    {
                        var waitTime = (grid[newRow][newCol] - timeLeft) % 2 == 0
                            ? 1 : 0;
                        var nextTime = Math.Max(grid[newRow][newCol] + waitTime, timeLeft + 1);
                        pq.Enqueue((newRow, newCol), nextTime);
                    }
                }
            }

            return -1;
        }
    }
}