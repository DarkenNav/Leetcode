
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Leetcode.LinkedList.Intro
{
    public class OddEvenLinkedListCase 
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
            var case1_head = new ListNode(new int[] { 1, 2, 3, 4, 5 }, 0);
            var case1_result = OddEvenList(case1_head);

            var case2_head = new ListNode(new int[] { 2, 1, 3, 5, 6, 4, 7 }, 0);
            var case2_result = OddEvenList(case2_head);

            var case3_result = OddEvenList(null);
        }

        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head?.next == null)
                return head;

            var node = head.next.next;
            var even = false;
            var oddNodeCursor = head;
            var evenNode = head.next;
            var evenNodeCursor = head.next;
            while (node != null)
            {
                if (!even)
                {
                    oddNodeCursor.next = node;
                    oddNodeCursor = node;
                    even = true;
                }
                else
                {
                    evenNodeCursor.next = node;
                    evenNodeCursor = node;
                    even = false;
                }
                node = node.next;
            }
            oddNodeCursor.next = evenNode;
            evenNodeCursor.next = null;
            return head;
        }
    }
}
