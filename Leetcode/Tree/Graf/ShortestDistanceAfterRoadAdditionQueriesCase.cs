using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.Tree.Graf
{
    /// <summary>
    /// 3243. Shortest Distance After Road Addition Queries I
    /// </summary>
    public class ShortestDistanceAfterRoadAdditionQueriesCase
        : IArrayLC, IGrafLC, IBreadthFirstLC
    {
        public void Cases()
        {
            // Output: [3,2,1]
            var result_0 = ShortestDistanceAfterQueries(5, [[2,4],[0,2],[0,4]]);
            // Output: [1,1]
            var result_1 = ShortestDistanceAfterQueries(4, [[0,3],[0,2]]);

        }

        public int[] ShortestDistanceAfterQueries(int n, int[][] queries)
        {
            var cities = new List<IList<int>>();
            // [0, 1], [1, 2], [2, 3], [3, 4], [4, 5] ... [n - 1, n]
            for(var i = 0; i < n; i++)
                cities.Add([i + 1]);
            
            var q = queries.Length;
            var result = new int[q];
            for(var i = 0; i < q; i++)
            {
                cities[queries[i][0]].Add(queries[i][1]);
                result[i] = SortestWayBFS(cities);
            }

            return result;
        }

        private int SortestWayBFS(List<IList<int>> cities)
        {
            var n = cities.Count;
            var queue = new Queue<(int city, int way)>();
            var visits = new bool[n];
            visits[0] = true;
            queue.Enqueue((0,0));
            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach(var city in cities[current.city])
                {
                    if(city == n)
                        return current.way;

                    if(!visits[city])
                    {
                        visits[city] = true;
                        queue.Enqueue((city, current.way + 1));
                    }
                }
            }
            return n;
        }
    }
}