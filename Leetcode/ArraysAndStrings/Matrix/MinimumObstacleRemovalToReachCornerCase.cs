using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.ArraysAndStrings.Matrix
{
    /// <summary>
    /// 2290. Minimum Obstacle Removal to Reach Corner
    /// </summary>
    public class MinimumObstacleRemovalToReachCornerCase
        : IArrayLC, IBreadthFirstLC, IGrafLC, IHeapLC, IPriorityQueueLC, IMatrixLC, IShortestPathLC
    {
        internal void Cases()
        {
            // Output: 2
            var result_0 = MinimumObstacles([[0,1,1],[1,1,0],[1,1,0]]);
            // Output: 0
            var result_1 = MinimumObstacles([[0,1,0,0,0],[0,1,0,1,0],[0,0,0,1,0]]);
        }

        public int MinimumObstacles(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;

            var minimumObstacles = new int[m][];
            for(var i = 0; i < m; i++){
                minimumObstacles[i] = new int[n]; 
                for(var j = 0; j < n; j++)
                    minimumObstacles[i][j] = int.MaxValue;
            }

            minimumObstacles[0][0] = grid[0][0];
            var pq = new PriorityQueue<int[], int>();
            pq.Enqueue([0,0], minimumObstacles[0][0]);

            int[][] directions = [[0,1],[0,-1,],[1,0],[-1,0]];

            while(pq.Count > 0)
            {
                _ = pq.TryDequeue(out int[] current, out int obstacles);
                var row = current[0];
                var col = current[1];
                if(row == m - 1 && col == n - 1)
                    return obstacles;

                foreach(var dir in directions)
                {
                    var newRow = row + dir[0];
                    var newCol = col + dir[1];
                    if(newRow >= 0 && newRow < grid.Length 
                        && newCol >= 0 && newCol < grid[0].Length)
                    {
                        var newObstacles = obstacles + grid[newRow][newCol];
                        if(newObstacles < minimumObstacles[newRow][newCol])
                        {
                            minimumObstacles[newRow][newCol] = newObstacles;
                            pq.Enqueue([newRow,newCol], newObstacles);
                        }
                    }
                }
            }

            return minimumObstacles[m-1][n-1];
        }
    }
}