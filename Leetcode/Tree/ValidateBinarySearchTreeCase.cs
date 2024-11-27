using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    public class ValidateBinarySearchTreeCase
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
            // Input: root = [2,1,3]
            var root_0 = new TreeNode(2, new TreeNode(1), new TreeNode(3));
            // Output: true
            var result_0 = IsValidBST(root_0);

            // Input: root = [5,1,4,null,null,3,6]
            var root_1 = new TreeNode(5, 
                new TreeNode(1,
                    null,
                    null), 
                new TreeNode(4,
                    new TreeNode(3),
                    new TreeNode(6)
                ));
            // Output: false
            var result_1 = IsValidBST(root_1);

            // Input: root = [5,4,6,null,null,3,7]
            var root_2 = new TreeNode(5,
                new TreeNode(4,
                    null,
                    null),
                new TreeNode(6,
                    new TreeNode(3),
                    new TreeNode(7)
                ));
            // Output: false
            var result_2 = IsValidBST(root_2);
        }

        // root     [int.MinValue, int.MaxValue]
        // l [int.MinValue, root.val] r [root.val, int.MaxValue]
        // l.l [int.MinValue, l.val] l.r [l.val, root.val] r.l [root.val, r.val] r.r [r.val, int.MaxValue]

        public bool IsValidBST(TreeNode root, 
            long min = long.MinValue, long max = long.MaxValue)
        {
            if (root == null) 
                return true;

            if(root.val <= min || root.val >= max)
                return false;

            return IsValidBST(root.left, min, root.val) && IsValidBST(root.right, root.val, max);
        }


    }
}
