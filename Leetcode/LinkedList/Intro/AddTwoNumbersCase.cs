
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkedList.Intro
{
    public class AddTwoNumbersCase 
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
            var case0_head1 = new ListNode(new int[] { 2, 4, 3 }, 0);
            var case0_head2 = new ListNode(new int[] { 5, 6, 4 }, 0);
            var case0_result = AddTwoNumbers(case0_head1, case0_head2);

            var case1_head1 = new ListNode(new int[] { 0 }, 0);
            var case1_head2 = new ListNode(new int[] { 0 }, 0);
            var case1_result = AddTwoNumbers(case1_head1, case1_head2);

            var case2_head1 = new ListNode(new int[] { 9, 9, 9, 9, 9, 9, 9 }, 0);
            var case2_head2 = new ListNode(new int[] { 9, 9, 9, 9 }, 0);
            var case2_result = AddTwoNumbers(case2_head1, case2_head2);

            var case3_head1 = new ListNode(new int[] { 9, 8 }, 0);
            var case3_head2 = new ListNode(new int[] { 1 }, 0);
            var case3_result = AddTwoNumbers(case3_head1, case3_head2);
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var result = new ListNode();
            var resultCursor = result;
            var list1Cursor = l1;
            var list2Cursor = l2;
            var oneInHead = 0; // :)
            while (!(list1Cursor == null && list2Cursor == null))
            {
                var l1_val = list1Cursor?.val ?? 0;
                var l2_val = list2Cursor?.val ?? 0;

                var summ = (l1_val + l2_val) % 10 + oneInHead;
                oneInHead = l1_val + l2_val + oneInHead >= 10 ? 1 : 0;

                resultCursor.val = summ < 10 ? summ : 0;
                if (!(list1Cursor?.next == null && list2Cursor?.next == null))
                {
                    resultCursor.next = new ListNode();
                    resultCursor = resultCursor.next;
                }

                if (list1Cursor != null)
                {
                    list1Cursor = list1Cursor.next;
                }
                if (list2Cursor != null)
                {
                    list2Cursor = list2Cursor.next;
                }
            }
            if(oneInHead != 0)
            {
                resultCursor.next = new ListNode(1);
            }

            return result;
        }
    }
}
