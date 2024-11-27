using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Tree.Info.BinaryTreeInorderTraversalCase;

namespace Leetcode.Reqursion.Intro
{
    public class SearchInBinarySearchTreeCase
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
            var node_0_0 = new TreeNode(4);
            node_0_0.left = new TreeNode(2);
            node_0_0.right = new TreeNode(7);
            var node_0_1 = node_0_0.left;
            node_0_1.left = new TreeNode(1);
            node_0_1.right = new TreeNode(3);

            var resilt_0 = SearchBST(node_0_0, 2);
            var resilt_1 = SearchBST(node_0_0, 5);
        }

        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
                return null;

            if(root.val == val)
                return root;

            var result = SearchBST(root.left, val);
            if(result != null)
                return result;

            result = SearchBST(root.right, val);
            return result;
        }
    }
}
