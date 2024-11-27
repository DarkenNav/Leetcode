using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    // 2641. Cousins in Binary Tree II
    public class CousinsInBinaryTreeIICase
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
            //Input: root = [5, 4, 9, 1, 10, null, 7]
            //Output: [0, 0, 0, 7, 7, null, 11]
            var root_0 = new TreeNode(5,
                new TreeNode(4,
                    new TreeNode(1),
                    new TreeNode(10)),
                new TreeNode(9,
                    null,
                    new TreeNode(7))
                );
            var result_0 = ReplaceValueInTree(root_0);
        }


        public TreeNode ReplaceValueInTree(TreeNode root)
        {
            if (root == null) 
                return root;

            var sums = new Dictionary<int, int>();
            LevelSumm(root, 0, sums);
            LevelSummExludeBro(root, 0, sums);

            root.val = 0;

            return root;
        }

        private void LevelSumm(TreeNode node, int lv, Dictionary<int, int> summ)
        {
            if (node == null) return;

            _ = summ.TryGetValue(lv, out int val);
            summ[lv] = node.val + val;

            LevelSumm(node.left, lv + 1, summ);
            LevelSumm(node.right, lv + 1, summ);
        }

        private void LevelSummExludeBro(TreeNode node, int lv, Dictionary<int, int> summ)
        {
            var broSum = (node.left != null ? node.left.val : 0) + (node.right != null ? node.right.val : 0);
            if (node.left != null)
            {
                node.left.val = summ[lv + 1] - broSum;
                LevelSummExludeBro(node.left, lv + 1, summ);
            }

            if (node.right != null)
            {
                node.right.val = summ[lv + 1] - broSum;
                LevelSummExludeBro(node.right, lv + 1, summ);
            }
        }

        // slow
        public TreeNode ReplaceValueInTree_1(TreeNode root)
        {
            var dictionary = new Dictionary<TreeNode, (int lv, TreeNode parent, int sum)>();
            LevelDefinition(root, null, 0, dictionary);
            foreach (var nodeKV in dictionary)
            {
                var sum = dictionary.Where(x =>
                        x.Key != nodeKV.Key
                            && x.Value.lv == nodeKV.Value.lv 
                            && !x.Value.parent.Equals(nodeKV.Value.parent))
                    .Sum(x => x.Key.val);

                dictionary[nodeKV.Key] = (nodeKV.Value.lv, nodeKV.Value.parent, sum);
            }

            foreach(var nodeKV in dictionary)
            {
                nodeKV.Key.val = nodeKV.Value.sum;
            }

            return root;
        }

        private void LevelDefinition(TreeNode node, TreeNode parent, int lv, 
            Dictionary<TreeNode, (int lv, TreeNode parent, int sum)> dictionary)
        {
            if (node == null) return;

            dictionary[node] = (lv, parent, 0);

            LevelDefinition(node.left, node, lv + 1, dictionary);
            LevelDefinition(node.right, node, lv + 1, dictionary);
        }
    }
}
