using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree.Info
{
    public class BinaryTreeLevelOrderTraversalCase
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
            // Input: root = [3,9,20,null,null,15,7]
            var root_0 = new TreeNode(3, 
                new TreeNode(9), 
                new TreeNode(20, 
                    new TreeNode(15), 
                    new TreeNode(7))
                );
            // Output: [[3],[9,20],[15,7]]
            var result_0 = LevelOrder(root_0);

            // Input: root = [1]
            // Output: [[1]]
            var result_1 = LevelOrder(new TreeNode(1));

            // Input: root = []
            // Output: []
            var result_2 = LevelOrder(null);
        }

        // -- Reqursion --------------------------------------------------
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            return LevelOrderReqursion(root, 0, new List<IList<int>>());
        }

        private IList<IList<int>> LevelOrderReqursion(TreeNode node, int lvl, IList<IList<int>> result)
        {
            if (node == null) 
                return result;

            if (result.Count <= lvl)
                result.Add(new List<int>());
            result[lvl].Add(node.val);

            LevelOrderReqursion(node.left, lvl + 1, result);
            LevelOrderReqursion(node.right, lvl + 1, result);

            return result;
        }

        // -- Queue ------------------------------------------------------
        public IList<IList<int>> LevelOrder_1(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null)
                return result;

            var queue = new Queue<(TreeNode, int)>();
            var maxLvl = 0;
            queue.Enqueue((root, 0));
            while (queue.Count > 0)
            {
                (TreeNode node, int lvl) = queue.Dequeue();
                var nextLvl = lvl + 1;
                if (nextLvl > maxLvl)
                {
                    maxLvl = nextLvl;
                    result.Add(new List<int>());
                }
                result[lvl].Add(node.val);

                if (node.left != null)
                    queue.Enqueue((node.left, nextLvl));
                if (node.right != null)
                    queue.Enqueue((node.right, nextLvl));
            }

            return result;
        }
    }
}
