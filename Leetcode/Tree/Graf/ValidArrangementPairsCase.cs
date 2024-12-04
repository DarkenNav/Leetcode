using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.Tree.Graf
{
    /// <summary>
    /// 2097. Valid Arrangement of Pairs
    /// </summary>
    public class ValidArrangementPairsCase
        : IDepthFirstSearchLC, IGrafLC, IEulerianCircuitLC
    {
        public void Cases()
        {
            // Output: [[11,9],[9,4],[4,5],[5,1]]
            var result_0 = ValidArrangement([[5,1],[4,5],[11,9],[9,4]]);
        }

        public int[][] ValidArrangement(int[][] pairs)
        {
            List<IList<int>> results = new List<IList<int>>();
            var graph = new Dictionary<int, Stack<int>>();
            var outDegree = new Dictionary<int, int>();
            var inDegree = new Dictionary<int, int>();

            foreach(var pair in pairs)
            {
                var start = pair[0];
                var end = pair[1];
                if(!graph.ContainsKey(start))
                    graph[start] = new Stack<int>();
                graph[start].Push(end);
                outDegree[start] = outDegree.GetValueOrDefault(start, 0) + 1;
                inDegree[end] = inDegree.GetValueOrDefault(end, 0) + 1;
            }

            var startNode = -1;
            foreach (int start in graph.Keys) {
                if (outDegree[start] - inDegree.GetValueOrDefault(start, 0) == 1) 
                {
                    startNode = start;
                    break;
                }
            }
            if(startNode == -1)
                startNode = pairs[0][0];

            Euler(graph, startNode, results);
            results.Reverse();
            return results.Select(x => x.ToArray()).ToArray();
        }

        private void Euler(Dictionary<int, Stack<int>> graph, 
            int start, List<IList<int>> results) 
        {
            _ = graph.TryGetValue(start, out var stack);
            while (stack?.Count > 0) {
                var end = stack.Pop();
                Euler(graph, end, results);
                results.Add([start, end]);
            }
        }
    }
}