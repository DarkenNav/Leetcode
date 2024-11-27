using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    public class UniqueBinarySearchTreesIICase
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
            // Output: [[1,null,2,null,3],[1,null,3,2],[2,1,3],[3,1,null,null,2],[3,2,null,1]]
            var result_0 = GenerateTrees(3);
            // Output: [[1]]
            var result_1 = GenerateTrees(1);
        }

        public IList<TreeNode> GenerateTrees(int n)
        {
            return allPossibleBST(1, n);
        }

        private Dictionary<(int start, int end), List<TreeNode>> memo = new();
        private IList<TreeNode> allPossibleBST(int start, int end)
        {
            var result = new List<TreeNode>();
            if (start > end)
            {
                result.Add(null);
                return result;
            }

            if (memo.ContainsKey((start, end)))
                return memo[(start, end)];

            for (var i = start; i <= end; i++)
            {
                var leftSubtrees = allPossibleBST(start, i - 1);
                var rightSubTrees = allPossibleBST(i + 1, end);

                foreach (var left in leftSubtrees)
                {
                    foreach (var right in rightSubTrees)
                    {
                        var root = new TreeNode(i, left, right);
                        result.Add(root);
                    }
                }
            }
            memo[(start, end)] = result;
            return result;
        }
    }
}
