using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree.Info
{
    public class BinaryTreePreorderTraversalCase
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
            var root_0 = new TreeNode(1);
            root_0.right = new TreeNode(2);
            root_0.right.left = new TreeNode(3);
            // Output: [1, 2, 3]
            var result_0 = PreorderTraversal(root_0).ToArray();

            Results.Clear();
            // Input: root = [1,2,3,4,5,null,8,null,null,6,7,9]
            var root_1 = new TreeNode(1, 
                new TreeNode(2, 
                    new TreeNode(4), 
                    new TreeNode(5, new TreeNode(6), new TreeNode(7))), 
                new TreeNode(3, 
                    null, 
                    new TreeNode(8, new TreeNode(9), null))
                );
            // Output: [1,2,4,5,6,7,3,8,9]
            var result_1 = PreorderTraversal(root_1).ToArray();
        }

        private List<int> Results = new List<int>();
        public IList<int> PreorderTraversal(TreeNode root)
        {
            if (root == null)
                return Results;

            Results.Add(root.val);
            PreorderTraversal(root.left);
            PreorderTraversal(root.right);

            return Results;
        }
    }
}
