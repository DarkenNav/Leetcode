using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.SortingAndSearching.Sorting
{
    internal class InsertionSortListCase
    {
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode()
            {
            }

            public ListNode(int x, ListNode next = null)
            {
                val = x;
                this.next = next;
            }

            public ListNode(int[] vals, int begin = 0)
            {
                val = vals[begin];
                if (begin + 1 < vals.Length)
                    next = new ListNode(vals, begin + 1);
            }
        }

        internal void Cases()
        {
            var root_0 = new ListNode([4, 2, 1, 3]);
            var result = InsertionSortList(root_0);
        }

        public ListNode InsertionSortList(ListNode head)
        {
            var dummy = new ListNode();
            var cursor = head;
            while(cursor != null)
            {
                var prev = dummy;
                while(prev.next != null && prev.next.val <= cursor.val)
                {
                    prev = prev.next;
                }

                var next = cursor.next;
                cursor.next = prev.next;
                prev.next = cursor;

                cursor = next;
            }

            return dummy.next;
        }
    }
}
