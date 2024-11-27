using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree.Info
{
    public class PathSumCase
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
            // Input: root = [5,4,8,11,null,13,4,7,2,null,null,null,1], targetSum = 22
            var node_0 = new TreeNode(5,
                new TreeNode(4,
                    new TreeNode(11,
                        new TreeNode(7),
                        new TreeNode(2)),
                    null),
                new TreeNode(8,
                    new TreeNode(13),
                    new TreeNode(4,
                        null,
                        new TreeNode(13)
                        ))
                );
            // true 
            var result_0 = HasPathSum(node_0, 22);

            // Input: root = [1,2,3], targetSum = 5
            var node_1 = new TreeNode(1,
                new TreeNode(2),
                new TreeNode(3)
                );
            // false
            var result_1 = HasPathSum(node_1, 5);

            // Input: root = [], targetSum = 0
            // Output: false
            var result_2 = HasPathSum(null, 0);
        }

        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if(root == null)
                return false;

            if (root.left == null && root.right == null)
            {
                return targetSum - root.val == 0;
            }

            return HasPathSum(root.left, targetSum - root.val) 
                || HasPathSum(root.right, targetSum - root.val);
        }


    }
}
