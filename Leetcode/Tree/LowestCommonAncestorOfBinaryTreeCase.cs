using Leetcode._Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    public class LowestCommonAncestorOfBinaryTreeCase : ITreeLC
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
            // Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
            var pNode_0 = new TreeNode(5,
                    new TreeNode(6),
                    new TreeNode(2,
                        new TreeNode(7),
                        new TreeNode(4)));
            var qNode_0 = new TreeNode(1,
                    new TreeNode(0),
                    new TreeNode(8));
            var root_0 = new TreeNode(3, pNode_0, qNode_0);
            // Output: 3
            var result_0 = LowestCommonAncestor(root_0, pNode_0, qNode_0);

            // Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
            var qNode_1 = new TreeNode(4);
            var pNode_1 = new TreeNode(5,
                    new TreeNode(6),
                    new TreeNode(2,
                        new TreeNode(7),
                        qNode_1));
            var root_1 = new TreeNode(3, 
                pNode_1, 
                new TreeNode(1,
                    new TreeNode(0),
                    new TreeNode(8)));
            // Output: 3
            var result_1 = LowestCommonAncestor(root_1, pNode_1, qNode_1);
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;

            if (root.val == p.val || root.val == q.val)
                return root;

            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);

            if (left != null && right != null)
                return root;

            return left ?? right;
        }

        private void PostorderTraversal(TreeNode node, TreeNode p, TreeNode q, List<int> results)
        {
            if (node == null)
                return;

            PostorderTraversal(node.left, p, q, results);
            PostorderTraversal(node.right, p, q, results);
            results.Add(node.val);
        }

        private TreeNode SearchNode(TreeNode node, TreeNode target1, TreeNode target2)
        {
            if (node == null)
                return null;

            if(node.val == target1.val || node.val == target2.val)
                return node;

            var left = SearchNode(node.left, target1, target2);
            var right = SearchNode(node.right, target1, target2);

            if (left != null && right != null)
                return node;

            return left ?? right;
        }
    }
}
