
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkedList.Intro
{
    public class RemoveLinkedListElementsCase 
    {
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode()
            {
            }

            public ListNode(int x)
            {
                val = x;
                next = null;
            }

            public ListNode(int[] vals, int begin)
            {
                val = vals[begin];
                if (begin + 1 < vals.Length)
                    next = new ListNode(vals, begin + 1);
            }
        }

        public void Case()
        {
            var case1_head = new ListNode(new int[] { 1, 2, 6, 3, 4, 5, 6 }, 0);
            var case1_result = RemoveElements(case1_head, 6);

            var case2_result = RemoveElements(null, 1);

            var case3_head = new ListNode(new int[] { 7, 7, 7, 7 }, 0);
            var case3_result = RemoveElements(case3_head, 7);

            var case4_head = new ListNode(new int[] { 7, 7, 7, 7, 1 }, 0);
            var case4_result = RemoveElements(case4_head, 7);

            var case5_head = new ListNode(new int[] { 1, 7, 7, 7, 7 }, 0);
            var case5_result = RemoveElements(case5_head, 7);

        }

        public ListNode RemoveElements(ListNode head, int val)
        {
            var node = head;
            ListNode prevNode = null;
            while (node != null)
            {
                if (node.val == val)
                {
                    if (prevNode == null)
                    {
                        head = node.next;
                    }
                    else
                    {
                        prevNode.next = node.next;
                    }
                }
                else
                {
                    prevNode = node;
                }
                node = node.next;
            }
            return head;
        }
    }
}
