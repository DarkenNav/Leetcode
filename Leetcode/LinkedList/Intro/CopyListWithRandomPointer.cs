
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkedList.Intro
{
    public class CopyListWithRandomPointer 
    {
        public class Node
        {
            public int val;
            public Node next;
            public Node prev;
            public Node child;
            public Node random;

            public Node()
            {
            }

            public Node(int x)
            {
                val = x;
            }

            public Node(int[] vals, int begin)
            {
                val = vals[begin];
                if (begin + 1 < vals.Length)
                    next = new Node(vals, begin + 1);
            }

            public void SetChild(int index, Node child)
            {
                var cursor = this;
                var counter = 0;
                while (cursor != null && counter < index)
                {
                    cursor = cursor.next;
                    counter++;
                }
                if (cursor != null)
                    cursor.child = child;
            }

            public List<int> ToListValue()
            {
                var list = new List<int>();
                var cursor = this;
                while (cursor != null)
                {
                    list.Add(cursor.val);
                    cursor = cursor.next;
                }
                return list;
            }
        }

        public void Case()
        {
            //var case1_head = new Node(7);
            //case1_head.next = new Node(13);
            //case1_head.next.next = new Node(11);
            //case1_head.next.next.next = new Node(10);
            //case1_head.next.next.next.next = new Node(1);
            //case1_head.next.random = case1_head;
            //case1_head.next.next.random = case1_head.next.next.next.next;
            //case1_head.next.next.next.random = case1_head.next.next;
            //case1_head.next.next.next.next.random = case1_head;

            //var case1_result = CopyRandomList(case1_head);
            //var case1_list = case1_result?.ToListValue(); // 1,2,3,7,8,11,12,9,10,4,5,6

            var case2_head = new Node(3);
            case2_head.next = new Node(3);
            case2_head.next.next = new Node(3);
            case2_head.next.random = case2_head;

            var case2_result = CopyRandomList(case2_head);
            var case2_list = case2_result?.ToListValue(); // 1,2,3,7,8,11,12,9,10,4,5,6
        }

        // а через 2 цикла производительнее)))
        public Node CopyRandomList(Node head)
        {
            if (head == null)
                return null;

            var result = new Node(head.val);
            var cursor = head;
            var resultCursor = result;
            var set = new HashSet<Tuple<Node, Node>>();
            set.Add(new Tuple<Node, Node>(cursor, resultCursor));
            while (cursor != null)
            {
                if (cursor.random != null)
                {
                    var cursorRandom = set.FirstOrDefault(x => x.Item1 == cursor.random);
                    if (cursorRandom != null)
                    {
                        resultCursor.random = cursorRandom.Item2;
                    }
                    else
                    {
                        resultCursor.random = new Node(cursor.random.val);
                        set.Add(new Tuple<Node, Node>(cursor.random, resultCursor.random));
                    }
                }

                cursor = cursor.next;
                if (cursor != null)
                {
                    var next = set.FirstOrDefault(x => x.Item1 == cursor);
                    if (next != null)
                    {
                        resultCursor.next = next.Item2;
                    }
                    else
                    {
                        resultCursor.next = new Node(cursor.val);
                        set.Add(new Tuple<Node, Node>(cursor, resultCursor.next));
                    }
                }
                resultCursor = resultCursor.next;
            }
            return result;
        }
    }
}

