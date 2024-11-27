using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    public class KthLargestSumInBinaryTreeCase
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
            var root_0 = new TreeNode(5, 
                new TreeNode(8, 
                    new TreeNode(2, 
                        new TreeNode(4), 
                        new TreeNode(6)), 
                    new TreeNode(1)), 
                new TreeNode(9, 
                    new TreeNode(3), 
                    new TreeNode(7))
                );
            //  Выход: 13
            var result_0 = KthLargestLevelSum(root_0, 2);

            var root_1 = new TreeNode(1, 
                new TreeNode(2, 
                    new TreeNode(3))
                );
            //  Выход: 3
            var result_1 = KthLargestLevelSum(root_1, 1);
        }

        public long KthLargestLevelSum(TreeNode root, int k)
        {
            var sums = new Dictionary<int, long>();
            LevelSumm(root, 0, sums);

            if (k > sums.Count)
                return -1;

            var orderedArr = sums
                .Select(x => x.Value)
                .OrderDescending()
                .ToArray();

            return orderedArr[k-1];
        }

        private void LevelSumm(TreeNode root, int lv, Dictionary<int, long> summ)
        {
            if(root == null) return;

            _ = summ.TryGetValue(lv, out long val);
            summ[lv] = root.val + val;

            LevelSumm(root.left, lv + 1, summ);
            LevelSumm(root.right, lv + 1, summ);
        }

    }
}
