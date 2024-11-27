using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    // 951. Flip Equivalent Binary Trees
    public class FlipEquivalentBinaryTreesCase
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
            //Input: root1 = [1, 2, 3, 4, 5, 6, null, null, null, 7, 8],
            //       root2 = [1, 3, 2, null, 6, 4, 5, null, null, null, null, 8, 7]
            //Output: true
            var result_0 = FlipEquiv(
                new TreeNode(1,
                    new TreeNode(2,
                        new TreeNode(4),
                        new TreeNode(5,
                            new TreeNode(7),
                            new TreeNode(8))),
                    new TreeNode(3,
                        new TreeNode(6),
                        null)
                    ),
                new TreeNode(1,
                    new TreeNode(3,
                        null,
                        new TreeNode(6)),
                    new TreeNode(2,
                        new TreeNode(4),
                        new TreeNode(5,
                            new TreeNode(8),
                            new TreeNode(7)))
                    )
                );

            // Выход: true
            var result_1 = FlipEquiv(null, null);

            // Выход: false
            var result_2 = FlipEquiv(null, new TreeNode(1));

            // Выход: false
            var result_3 = FlipEquiv(
                new TreeNode(0,
                    null,
                    new TreeNode(1)),
                null);

            // Выход: true
            var result_4 = FlipEquiv(
                new TreeNode(0,
                    null,
                    new TreeNode(1)),
                new TreeNode(0,
                    new TreeNode(1),
                    null)
                );

        }

        public bool FlipEquiv(TreeNode root1, TreeNode root2)
        {
            if (!TreeNodeEquiv(root1, root2))
                return false;

            return !FlipNotEquivReqursive(root1, root2);
        }

        private bool TreeNodeEquiv(TreeNode node1, TreeNode node2)
        {
            return (node1 == null && node2 == null)
                || (node1 != null && node2 != null && node1.val == node2.val);
        }

        private bool FlipNotEquivReqursive(TreeNode node1, TreeNode node2)
        {
            if (node1 == null && node2 == null)
                return false;
            if ((node1 == null && node2 != null) || (node1 != null && node2 == null))
                return true;

            if (!TreeNodeEquiv(node1.left, node2.left) || !TreeNodeEquiv(node1.right, node2.right))
            {
                // try flip
                if(!TreeNodeEquiv(node1.left, node2.right) || !TreeNodeEquiv(node1.right, node2.left))
                    return true;

                var tmp = node1.left;
                node1.left = node1.right;
                node1.right = tmp;
            }

            return FlipNotEquivReqursive(node1.left, node2.left) || FlipNotEquivReqursive(node1.right, node2.right);
        }



    }
}
