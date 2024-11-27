
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkedList.Intro
{
    public class PalindromeLinkedListCase 
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
            var case0_head = new ListNode(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0);
            var case0_result = IsPalindrome(case0_head);

            var case1_head = new ListNode(new int[] { 1, 2, 2, 1 }, 0);
            var case1_result = IsPalindrome(case1_head);

            var case2_head = new ListNode(new int[] { 1, 2 }, 0);
            var case2_result = IsPalindrome(case2_head);

            var case3_result = IsPalindrome(null);

            var case4_head = new ListNode(new int[] { 1 }, 0);
            var case4_result = IsPalindrome(case4_head);
        }

        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head?.next == null)
                return true;

            // Find midle
            var fast_cursor = head;
            var slow_Cursor = head;
            var count = 0;
            while (fast_cursor != null && fast_cursor.next != null)
            {
                fast_cursor = fast_cursor.next;
                if(count % 2 == 0)
                {
                    slow_Cursor = slow_Cursor.next;
                }
                count++;
            }

            // reverse slow_Cursor
            var node = slow_Cursor;
            var nodeNext = node.next;
            var reverse = slow_Cursor;
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

            // Check Palindrome
            var left = head;
            var right = reverse;
            while(right != null)
            {
                if(left.val != right.val)
                {
                    return false;
                }
                left = left.next;
                right = right.next;
            }

            return true;
        }
    }
}
