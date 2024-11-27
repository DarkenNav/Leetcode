using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    public class ConstructBinaryTreeFromInorderAndPostorderTraversalCase
    {
        // https://www.geeksforgeeks.org/construct-a-binary-tree-from-postorder-and-inorder/
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

        // Даны два целочисленных массива inorder и postorder ,
        // где inorder — обход бинарного дерева в прямом порядке,
        // а postorder — обход того же дерева в обратном порядке.
        // Создайте и верните бинарное дерево.
        public void Cases()
        {
            // Вывод: [3,9,20,null,null,15,7]
            var result_0 = BuildTree([9, 3, 15, 20, 7], [9, 15, 7, 20, 3]);
        }

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            var n = postorder.Length;
            var index = n - 1;

            var mp = new Dictionary<int, int>();
            for(var i = 0; i < n; i++)
            {
                mp[inorder[i]] = i;
            }

            var root = Build(inorder, postorder, 0, n - 1, ref index, mp);

            return root;
        }

        private TreeNode Build(int[] inorder, int[] postorder, 
            int start, int end, ref int index, Dictionary<int, int> mp)
        {
            if (start > end) 
                return null;

            var node = new TreeNode(postorder[index]);
            index--;

            if (start == end)
                return node;

            //var i = SearchByValue(inorder, start, end, node.val);
            var i = mp[node.val];

            node.right = Build(inorder, postorder, i + 1, end, ref index, mp);

            node.left = Build(inorder, postorder, start, i - 1, ref index, mp);

            return node;
        }

        private int SearchByValue(int[] arr, int start, int end, int val)
        {
            int i;
            for(i = start; i <= end; i++)
            {
                if(arr[i] == val)
                    return i;
            }
            return -1;
        }
    }
}
