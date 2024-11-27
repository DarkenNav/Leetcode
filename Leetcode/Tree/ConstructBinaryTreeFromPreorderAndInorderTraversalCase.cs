using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    internal class ConstructBinaryTreeFromPreorderAndInorderTraversalCase
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

        internal void Cases()
        {
            // Output: [3,9,20,null,null,15,7]
            var result = BuildTree([3, 9, 20, 15, 7], [9, 3, 15, 20, 7]);
        }

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            var n = preorder.Length;
            var index = 0;

            var map = new Dictionary<int, int>();
            for (var i = 0; i < n; i++)
            {
                map[inorder[i]] = i;
            }

            var root = Build(preorder, map, 0, n - 1, ref index);

            return root;
        }

        // Input: preorder = [3,9,20,15,7], inorder = [9,3,15,20,7]
        private TreeNode Build(int[] preorder, Dictionary<int, int> map,
            int start, int end, ref int index)
        {
            if (start > end)
                return null;

            var node = new TreeNode(preorder[index]);
            index++;

            var i = map[preorder[index - 1]];

            node.left = Build(preorder, map, start, i - 1, ref index);

            node.right = Build(preorder, map, i + 1, end, ref index);

            return node;
        }
    }
}
