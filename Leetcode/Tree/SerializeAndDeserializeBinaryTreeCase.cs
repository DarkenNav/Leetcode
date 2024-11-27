using Leetcode._Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    public class SerializeAndDeserializeBinaryTreeCase : ITreeLC
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
            // Input: root = [1,2,3,null,null,4,5]
            var root = new TreeNode(1,
                new TreeNode(2),
                new TreeNode(3,
                    new TreeNode(4),
                    new TreeNode(5, null, new TreeNode(6))));

            // Output: [1, 2, 3, null, null, 4, 5]
            var ser = new Codec();
            var deser = new Codec();
            string serStr = ser.serialize(root);
            TreeNode deserTree = deser.deserialize(serStr);

            string serStr_1 = ser.serialize(null);
            TreeNode deserTree_1 = deser.deserialize(serStr_1);

            string serStr_2 = "1,2,3,,,4,5";
            TreeNode deserTree_2 = deser.deserialize(serStr_2);
        }

        public class Codec
        {
            // Encodes a tree to a single string.
            public string serialize(TreeNode root)
            {
                if(root == null)
                    return string.Empty;

                var list = new List<int?>();
                list.Add(root?.val);

                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                while (queue.Count > 0)
                {
                    for (var i = queue.Count; i > 0; i--)
                    {
                        var node = queue.Dequeue();                        

                        if (node.left != null)
                            queue.Enqueue(node.left);
                        if (node.right != null)
                            queue.Enqueue(node.right);

                        list.Add(node.left?.val);
                        list.Add(node.right?.val);
                    }
                }

                return string.Join(',', list);
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data)
            {
                if (string.IsNullOrWhiteSpace(data))
                    return null;
                var vals = data.Split(',');
                if (vals == null || vals.Length < 1 
                    || !int.TryParse(vals[0], out int rootVal))
                    return null;

                var n = vals.Length;
                var queue = new Queue<TreeNode>();
                var root = new TreeNode(rootVal);
                queue.Enqueue(root);
                var index = 0;
                while (queue.Count > 0)
                {
                    for (var i = queue.Count; i > 0; i--)
                    {
                        var node = queue.Dequeue();
                        if (index + 1 < n 
                            && int.TryParse(vals[++index], out int valLeft))
                        {
                            node.left = new TreeNode(valLeft);
                            queue.Enqueue(node.left);
                        }

                        if (index + 1 < n 
                            && int.TryParse(vals[++index], out int valRight))
                        {
                            node.right = new TreeNode(valRight);
                            queue.Enqueue(node.right);
                        }
                    }
                }

                return root;
            }
        }
    }
}
