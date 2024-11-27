using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    public class ConvertSortedArrayToBinarySearchTreeCase
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
            var result_0 = SortedArrayToBST([-10, -3, 0, 5, 9]);
        }

        public TreeNode SortedArrayToBST(int[] nums)
        {
            var n = nums.Length;
            var midle = (n - 1) / 2;
            var queue = new Queue<(TreeNode node, int start, int end)>();
            // root
            var root = new TreeNode(nums[midle]);
            queue.Enqueue((root, 0, n - 1));
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                var index = curr.start + (curr.end - curr.start) / 2;
                // left subtree
                if(index > curr.start)
                {
                    var midLeft = curr.start + ((index - 1) - curr.start) / 2;
                    var nodeLeft = new TreeNode(nums[midLeft]);
                    curr.node.left = nodeLeft;
                    queue.Enqueue((nodeLeft, curr.start, (index - 1)));
                }
                // right subtree
                if (index < curr.end)
                {
                    var midRight = (index + 1) + (curr.end - (index + 1)) / 2;
                    var nodeRight = new TreeNode(nums[midRight]);
                    curr.node.right = nodeRight;
                    queue.Enqueue((nodeRight, (index + 1), curr.end));
                }
            }
            return root;
        }
    }
}
