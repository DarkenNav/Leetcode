using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Reqursion.Intro
{
    public class MaximumDepthBinaryTreeCase
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
            var root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            root.right.right.right = new TreeNode(22);

            var result = MaxDepth(root);
        }

        public int MaxDepth(TreeNode root, int depth = 0)
        {
            if(root == null)
                return depth;

            return Math.Max(
                MaxDepth(root.left, depth + 1),
                MaxDepth(root.right, depth + 1)
                );
        }
    }
}
