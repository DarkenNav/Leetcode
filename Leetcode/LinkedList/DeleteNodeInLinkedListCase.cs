using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkedList
{
    public class DeleteNodeInLinkedListCase
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
            }

            public ListNode(int[] vals, int begin = 0)
            {
                val = vals[begin];
                if (begin + 1 < vals.Length)
                    next = new ListNode(vals, begin + 1);
            }

            public ListNode FindFirstVal(int val)
            {
                var cursor = this;
                while(cursor != null)
                {
                    if (cursor.val == val)
                        return cursor;
                    cursor = cursor.next;
                }
                return null;
            }
        }

        private ListNode Root_0 = new ListNode([4, 5, 1, 9]);
        private ListNode Root_1 = new ListNode([4, 5, 1, 9]);

        public void Cases()
        {
            // Output: [4,1,9]
            DeleteNode(Root_0.FindFirstVal(5));

            // Output: [4,5,9]
            DeleteNode(Root_1.FindFirstVal(1));
        }

        // The value of each node in the list is unique.
        // The node to be deleted is in the list and is not a tail node.
        public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
    }
}
