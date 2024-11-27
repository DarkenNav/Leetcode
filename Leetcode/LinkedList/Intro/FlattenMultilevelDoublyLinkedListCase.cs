
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Leetcode.LinkedList.Intro
{
    public class FlattenMultilevelDoublyLinkedListCase 
    {
        public class Node
        {
            public int val;
            public Node next;
            public Node prev;
            public Node child;

            public Node()
            {
            }

            public Node(int x)
            {
                val = x;
                next = null;
                prev = null;
                child = null;
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
                while(cursor != null && counter < index)
                {
                    cursor = cursor.next;
                    counter++;
                }
                if(cursor != null)
                    cursor.child = child;
            }

            public List<int> ToListValue() 
            { 
                var list = new List<int>();
                var cursor = this;
                while(cursor != null)
                {
                    list.Add(cursor.val);
                    cursor = cursor.next;
                }
                return list;
            }
        }
        public void Case()
        {
            var case1_head1 = new Node(new int[] { 1, 2, 3, 4, 5, 6 }, 0);
            var case1_head2 = new Node(new int[] { 7, 8, 9, 10 }, 0);
            case1_head1.SetChild(2, case1_head2);
            var case1_head3 = new Node(new int[] { 11, 12 }, 0);
            case1_head2.SetChild(1, case1_head3);
            var case1_result = Flatten(case1_head1);
            var case1_list = case1_result?.ToListValue(); // 1,2,3,7,8,11,12,9,10,4,5,6

            var case2_head1 = new Node(new int[] { 1, 2 }, 0);
            var case2_head2 = new Node(new int[] { 3 }, 0);
            case2_head1.SetChild(0, case2_head2);
            var case2_result = Flatten(case2_head1);
            var case2_list = case2_result?.ToListValue(); // 1,3,2

            var case3_result = Flatten(null);
            var case3_list = case3_result?.ToListValue(); // null

            // [1,2,3,4,5,6,null,null,null,7,8,null,null,11,12]
            var case4_head1 = new Node(new int[] { 1, 2, 3, 4, 5, 6 }, 0);
            var case4_head2 = new Node(new int[] { 7, 8 }, 0);
            case4_head1.SetChild(2, case4_head2);
            var case4_head3 = new Node(new int[] { 11, 12 }, 0);
            case4_head2.SetChild(1, case4_head3);
            var case4_result = Flatten(case4_head1);
            var case4_list = case4_result?.ToListValue(); // 1,2,3,7,8,11,12,4,5,6
        }
        public Node Flatten(Node head)
        {
            var result = head;
            var cursor = head;
            var resultCursor = head;
            var checkPoints = new HashSet<Node>();
            while (cursor != null)
            {                
                if (cursor.child != null)
                {
                    if(cursor.next != null)
                        checkPoints.Add(cursor.next);
                    var child = cursor.child;
                    cursor.child = null;
                    cursor = child;
                }
                else if(cursor.next == null)
                {
                    cursor = checkPoints.LastOrDefault();
                    if (cursor != null)
                    {
                        checkPoints.Remove(cursor);
                    }
                }
                else
                    cursor = cursor.next;

                if (cursor != null)
                {
                    cursor.prev = resultCursor;
                    resultCursor.next = cursor;
                    resultCursor = resultCursor.next;
                }
            }
            return result;
        }
    }
}
