using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    public class HeightBinaryTreeAfterSubtreeRemovalQueriesCase
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
            // Input: root = [1, 3, 4, 2, null, 6, 5, null, null, null, null, null, 7],
            // queries = [4]
            var root_0 = new TreeNode(1, 
                new TreeNode(3, 
                    new TreeNode(2),
                    null),
                new TreeNode(4, 
                    new TreeNode(6), 
                    new TreeNode(5,
                        null,
                        new TreeNode(7)))
                );
            // Output: [2]
            var result_0 = TreeQueries(root_0, [4]);

            // Входные данные: root = [5, 8, 9, 2, 1, 3, 7, 4, 6],
            // requests = [3, 2, 4, 8]
            var root_1 = new TreeNode(5,
                new TreeNode(8,
                    new TreeNode(2,
                        new TreeNode(4),
                        new TreeNode(6)
                    ),
                    new TreeNode(1)
                    ),
                new TreeNode(9,
                    new TreeNode(3),
                    new TreeNode(7)
                    )
                );
            // Выходные данные: [3, 2, 3, 2]
            var result_1 = TreeQueries(root_1, [3, 2, 4, 8]);
        }

        public int[] TreeQueries(TreeNode root, int[] queries)
        {
            var heights = new Dictionary<TreeNode, int>();
            var maxLevels = new Dictionary<int, int>();
            СalculationLevels(root, 0, 0, heights, maxLevels);

            var result = new int[queries.Length];
            for (var i = 0; i < queries.Length; i++) {
                result[i] = maxLevels[queries[i]];
            }

            return result;
        }

        private void СalculationLevels(TreeNode node, int lv, int maxLvl,
            Dictionary<TreeNode, int> heights, Dictionary<int, int> maxLevels)
        {
            if(node == null)
                return;

            maxLevels[node.val] = maxLvl;

            СalculationLevels(node.left, lv + 1, 
                Math.Max(maxLvl, lv + 1 + Height(node.right, heights)),
                heights, maxLevels);
            СalculationLevels(node.right, lv + 1,
                Math.Max(maxLvl, lv + 1 + Height(node.left, heights)),
                heights, maxLevels);
        }

        private int Height(TreeNode node, Dictionary<TreeNode, int> heights)
        {
            if (node == null)
                return -1;

            if(heights.TryGetValue(node, out int lvl))
                return lvl;

            var height = 1 + Math.Max(
                    Height(node.left, heights), 
                    Height(node.right, heights));

            heights[node] = height;
            return height;
        }
    }
}
