
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkedList.Intro
{
    public class RemoveNthNodeFromEndOfListCase 
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
            //var case1_head = new ListNode(new int[] { 1, 2, 3, 4, 5 }, 0);
            //var case1_result = RemoveNthFromEnd(case1_head, 2);

            var case2_head = new ListNode(new int[] { 1 }, 0);
            var case2_result = RemoveNthFromEnd(case2_head, 1);

            //var case3_head = new ListNode(new int[] { 1, 2 }, 0);
            //var case3_result = RemoveNthFromEnd(case3_head, 1);

            //var case4_head = new ListNode(new int[] { 1, 2, 3, 4 }, 0);
            //var case4_result = RemoveNthFromEnd(case4_head, 8);

            var case4_head = new ListNode(new int[] { 1, 2 }, 0);
            var case4_result = RemoveNthFromEnd(case4_head, 2);
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var current = head;
            var target = head;
            var count = 0;
            var shift = 1;
            while (current != null)
            {
                if (shift > n + 1)
                {
                    target = target.next;
                }
                else
                {
                    shift++;
                }

                current = current.next;
                count++;
            }

            if (count == n)
            {
                return head.next;
            }
            else if(count > n)
            {
                target.next = target.next?.next;
            }

            return head;
        }
    }
}
