using Leetcode._Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tree
{
    // 116. Populating Next Right Pointers in Each Node
    // 117. Populating Next Right Pointers in Each Node II
    public class PopulatingNextRightPointersInEachNodeCase : ITreeLC
    {
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node(int val = 0, Node left = null, Node right = null, Node next = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public void Cases()
        {
            // Input: root = [1,2,3,4,5,6,7]
            var root_0 = new Node(1, 
                new Node(2, 
                    new Node(4),
                    new Node(5)
                ),
                new Node(3,
                    new Node(6),
                    new Node(7)
                ));
            // Output: [1,#,2,3,#,4,5,6,7,#]
            var result_0 = Connect(root_0);
        }

        // Queue
        public Node Connect_queue(Node root)
        {
            if(root == null)
                return null;

            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                Node prevNode = null;
                for (var i = queue.Count; i > 0; i--)
                {
                    var current = queue.Dequeue();

                    if(prevNode != null)
                        prevNode.next = current;

                    prevNode = current;

                    if(current.left != null)
                        queue.Enqueue(current.left);
                    if (current.right != null)
                        queue.Enqueue(current.right);
                }
            }

            return root;
        }

        // Stack
        public Node Connect_stack(Node root)
        {
            if (root == null)
                return null;

            var stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                Node prevNode = null;
                for (var i = stack.Count; i > 0; i--)
                {
                    var current = stack.Pop();

                    if (prevNode != null)
                        prevNode.next = current;

                    prevNode = current;

                    if (current.right != null)
                        stack.Push(current.right);
                    if (current.left != null)
                        stack.Push(current.left);
                }
            }

            return root;
        }

        // Reqursion
        public Node Connect(Node root)
        {
            if (root == null)
                return null;

            ConnectReqursion([root]);
            return root;
        }

        private void ConnectReqursion(List<Node> nodes)
        {
            var childs = new List<Node>();
            Node prevNode = null; 
            foreach(var current in nodes)
            {
                if (prevNode != null)
                    prevNode.next = current;

                prevNode = current;

                if (current.left != null)
                    childs.Add(current.left);
                if (current.right != null)
                    childs.Add(current.right);
            }

            if (childs.Count > 0)
                ConnectReqursion(childs);
        }

    }
}
