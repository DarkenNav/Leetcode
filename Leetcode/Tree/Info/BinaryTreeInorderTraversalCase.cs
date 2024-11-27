
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree.Info
{
    public class BinaryTreeInorderTraversalCase
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public void Cases()
        {
            // Input: root = [1,null,2,3]
            var node_0 = new TreeNode(1,
                null,
                new TreeNode(2,
                    new TreeNode(3),
                    null)
                );
            // Output: [1,3,2]
            Results.Clear();
            var result_0 = InorderTraversal(node_0).ToArray();

            // Input: root = [1, 2, 3, 4, 5, null, 8, null, null, 6, 7, 9]
            var node_1 = new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(4),
                    new TreeNode(5,
                        new TreeNode(6),
                        new TreeNode(7))),
                new TreeNode(3,
                    null,
                    new TreeNode(8,
                        new TreeNode(9),
                        null))
                );
            // Output: [4,2,6,5,7,1,3,9,8]
            Results.Clear();
            var result_1 = InorderTraversal(node_1).ToArray();

            // Input: root = [], Output: []
            Results.Clear();
            var result_2 = InorderTraversal(null).ToArray();

            // Input: root = [1]
            var node_3_1 = new TreeNode(1);
            // Output: [1]
            Results.Clear();
            var result_3 = InorderTraversal(node_3_1).ToArray();
        }

        // -- Reqursion ----------------------------------------------
        private List<int> Results = new List<int>();
        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null)
                return Results;

            InorderTraversal(root.left);
            Results.Add(root.val);
            InorderTraversal(root.right);

            return Results;
        }

        // -- Stack ---------------------------------------------------
        private class Visit
        {
            public bool On = false;
        }

        public IList<int> InorderTraversal_1(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
                return result;
            if (root.right == null && root.left == null)
            {
                result.Add(root.val);
                return result;
            }

            var stack = new Stack<(TreeNode item, Visit visit)>();
            stack.Push((root, new Visit()));
            while (stack.Count > 0)
            {
                var node = stack.Peek();
                if (node.item.left == null || node.visit.On)
                {
                    stack.Pop();
                    result.Add(node.item.val);
                    if (node.item.right != null)
                    {
                        stack.Push((node.item.right, new Visit()));
                    }
                }
                else
                {
                    if (!node.visit.On)
                    {
                        stack.Push((node.item.left, new Visit()));
                        node.visit.On = true;
                    }
                    else
                    {
                        stack.Pop();
                        result.Add(node.item.val);
                    }
                }
            }
            return result;
        }
    }
}
