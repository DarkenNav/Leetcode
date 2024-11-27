
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack.StackAndDFS.Intro
{
    public class CloneGraphCase 
    {
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

        public void Case()
        {
            // Input: adjList = [[2, 4], [1, 3], [2, 4], [1, 3]]
            // Output: [[2,4],[1,3],[2,4],[1,3]]
            var node_0_1 = new Node() { val = 1 };
            var node_0_2 = new Node() { val = 2 };
            var node_0_3 = new Node() { val = 3 };
            var node_0_4 = new Node() { val = 4 };
            node_0_1.neighbors.Add(node_0_2);
            node_0_1.neighbors.Add(node_0_4);
            node_0_2.neighbors.Add(node_0_1);
            node_0_2.neighbors.Add(node_0_3);
            node_0_3.neighbors.Add(node_0_2);
            node_0_3.neighbors.Add(node_0_4);
            node_0_4.neighbors.Add(node_0_1);
            node_0_4.neighbors.Add(node_0_3);

            var result_0 = CloneGraph(node_0_1);

            var result_1 = CloneGraph(null);

            var node_2_1 = new Node() { val = 1 };
            var result_2 = CloneGraph(node_2_1);
        }

        public Node CloneGraph(Node node)
        {
            if (node == null)
                return null;

            var stack = new Stack<(Node, Node)>();
            var visits = new HashSet<(Node, Node)?>();
            var newHead = new Node(node.val);
            stack.Push((node, newHead));
            visits.Add((node, newHead));
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                foreach ( var neighbor in current.Item1.neighbors )
                {
                    var visit = visits.FirstOrDefault(x => x.Value.Item1 == neighbor);
                    if (visit == null)
                    {
                        var newNode = new Node(neighbor.val);
                        stack.Push((neighbor, newNode));
                        visits.Add((neighbor, newNode));
                        current.Item2.neighbors.Add(newNode);
                    }
                    else
                    {
                        current.Item2.neighbors.Add(visit.Value.Item2);
                    }
                }
            }

            return newHead;
        }
    }
}
