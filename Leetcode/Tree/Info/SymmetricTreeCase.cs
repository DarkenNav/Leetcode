using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree.Info
{
    public class SymmetricTreeCase
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
            // Input: root = [1,2,2,3,4,4,3]
            var node_0 = new TreeNode(1, 
                new TreeNode(2,
                    new TreeNode(3),
                    new TreeNode(4)), 
                new TreeNode(2,
                    new TreeNode(4),
                    new TreeNode(3))
                );
            // true
            var result_0 = IsSymmetric(node_0);

            // Input: root = [1,2,2,null,3,null,3]
            var node_1 = new TreeNode(1,
                new TreeNode(2,
                    null,
                    new TreeNode(3)),
                new TreeNode(2,
                    null,
                    new TreeNode(3))
                );
            // false
            var result_1 = IsSymmetric(node_1);

            // Input: root = [2,3,3,4,5,5,4,null,null,8,9,null,null,9,8]
            var node_2 = new TreeNode(2,
                new TreeNode(3,
                    new TreeNode(4),
                    new TreeNode(5, 
                        new TreeNode(8), 
                        new TreeNode(9))),
                new TreeNode(3,
                    new TreeNode(5),
                    new TreeNode(4, 
                        new TreeNode(9), 
                        new TreeNode(8)))
                );
            // false
            var result_2 = IsSymmetric(node_2);
        }

        // -- более элегантное зеркало без доп пространства
        public bool IsSymmetric(TreeNode root)
        {
            return IsMirror(root.left, root.right);
        }

        public bool IsMirror(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
                return true;

            if(left == null || right == null)
                return false;

            return right.val == left.val
                && IsMirror(left.left, right.right)
                && IsMirror(left.right, right.left);
        }

        // -- 
        public bool IsSymmetric_0(TreeNode root)
        {
            var lvls = LevelOrderReqursion(root, 0, new List<IList<int>>());
            // last = alwais  int.MinValue
            for (var i = 1; i < lvls.Count - 1; i++)
            {
                var left = 0;
                var right = lvls[i].Count - 1;
                while(left < right)
                {
                    if(lvls[i][left] != lvls[i][right])
                        return false;
                    left++;
                    right--;
                }
            }
            return true;
        }

        private IList<IList<int>> LevelOrderReqursion(TreeNode node, int lvl, IList<IList<int>> result)
        {
            if (result.Count <= lvl)
                result.Add(new List<int>());
            
            if (node == null)
            {
                result[lvl].Add(int.MinValue);
                return result;
            }
            result[lvl].Add(node.val);

            //if(node.left == null && node.right == null)
            //    return result;

            LevelOrderReqursion(node.left, lvl + 1, result);
            LevelOrderReqursion(node.right, lvl + 1, result);

            return result;
        }
    }
}
