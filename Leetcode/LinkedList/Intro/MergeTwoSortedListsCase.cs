
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkedList.Intro
{
    public class MergeTwoSortedListsCase 
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
            var case0_head1 = new ListNode(new int[] { 1, 2, 4 }, 0);
            var case0_head2 = new ListNode(new int[] { 1, 3, 4 }, 0);
            var case0_result = MergeTwoLists(case0_head1, case0_head2);

            var case3_result = MergeTwoLists(null, null);

            var case4_head = new ListNode(new int[] { 0 }, 0);
            var case4_result = MergeTwoLists(null, case4_head);

            var case5_head = new ListNode(new int[] { 0 }, 0);
            var case5_result = MergeTwoLists(case5_head, null);

            var case6_head1 = new ListNode(new int[] { 100 }, 0);
            var case6_head2 = new ListNode(new int[] { 1, 3, 4 }, 0);
            var case6_result = MergeTwoLists(case6_head1, case6_head2);
            var case7_result = MergeTwoLists(case6_head2, case6_head1);
        }

        // Reqursion ----------------------------------------------
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null)
                return list2;
            if (list2 == null)
                return list1;

            var result = list2;
            if (list1.val < list2.val)
            {
                result = list1;
                Merge(result, list1.next, list2);
            }
            else
                Merge(result, list1, list2.next);

            return result;
        }

        public void Merge(ListNode merged, ListNode list1, ListNode list2)
        {
            if (list1 == null)
            {
                merged.next = list2;
                return;
            }
            if (list2 == null)
            {
                merged.next = list1;
                return;
            }

            if (list1.val < list2.val)
            {
                merged.next = list1;
                Merge(merged.next, list1.next, list2);
            }
            else
            {
                merged.next = list2;
                Merge(merged.next, list1, list2.next);
            }
        }

        // -------------------------------------------------------
        public ListNode MergeTwoLists_0(ListNode list1, ListNode list2)
        {
            if (list1 == null)
                return list2;
            if(list2 == null)
                return list1;

            var merged = list2;
            var list1Cursor = list1;
            var list2Cursor = list2;
            if (list1.val < list2.val)
            {
                merged = list1;
                list1Cursor = list1.next;
            }
            else 
            {
                merged = list2;
                list2Cursor = list2.next;
            }

            var mergedCursor = merged;
            while (list1Cursor != null && list2Cursor != null)
            {
                if (list1Cursor.val  < list2Cursor?.val)
                {
                    mergedCursor.next = list1Cursor;
                    list1Cursor = list1Cursor.next;
                }
                else
                {
                    mergedCursor.next = list2Cursor;
                    list2Cursor = list2Cursor.next;
                }
                mergedCursor = mergedCursor.next;
            }
            mergedCursor.next = list1Cursor != null ? list1Cursor : list2Cursor;

            return merged;
        }
    }
}
