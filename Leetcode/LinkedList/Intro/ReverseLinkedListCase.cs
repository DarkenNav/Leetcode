
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkedList.Intro
{
    public class ReverseLinkedListCase 
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

        public void Cases()
        {
            var case1_head = new ListNode(new int[] { 1, 2, 3, 4, 5 }, 0);
            var case1_result = ReverseList(case1_head);

            var case2_head = new ListNode(new int[] { 1, 2 }, 0);
            var case2_result = ReverseList(case2_head);

            var case3_result = ReverseList(null);

            var case4_head = new ListNode(new int[] { 1 }, 0);
            var case4_result = ReverseList(case4_head);

        }

        // recursion
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return null;

            if(head.next == null)
                return head;

            var temp = head.next;
            head.next = null;

            return ReverseReqursion(head, temp);
        }

        private ListNode ReverseReqursion(ListNode head, ListNode node)
        {
            if(node == null)
                return head;

            var temp = node.next; // 3
            node.next = head;
            head = node;

            return ReverseReqursion(head, temp);
        }

        // while + cursors
        public ListNode ReverseList_While(ListNode head)
        {
            if (head == null)
                return null;

            var node = head;
            var nodeNext = node.next;
            var reverse = head;
            while (node != null && node.next != null) 
            {
                nodeNext = node.next;
                node.next = node.next.next;

                if (reverse == head)
                {
                    reverse = nodeNext;
                    nodeNext.next = node;
                }
                else
                {
                    nodeNext.next = reverse;
                    reverse = nodeNext;
                }
            }
            return reverse;
        }
    }
}
