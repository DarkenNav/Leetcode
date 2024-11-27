using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkedList
{
    public class MiddleOfLinkedListCase
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

            public ListNode(int[] vals, int begin = 0)
            {
                val = vals[begin];
                if (begin + 1 < vals.Length)
                    next = new ListNode(vals, begin + 1);
            }
        }

        public void Cases()
        {
            // Output: [3,4,5]
            var result_0 = MiddleNode(new ListNode([1, 2, 3, 4, 5]));
            // Output: [4,5,6]
            var result_1 = MiddleNode(new ListNode([1, 2, 3, 4, 5, 6]));
        }

        public ListNode MiddleNode(ListNode head)
        {
            var next = head;
            var result = head;
            var fast = 1;
            var slow = 0;
            while (next != null)
            {
                if (fast % 2 == 0)
                {
                    slow++;
                    result = result.next;
                }
                fast++;
                next = next.next;   
            }
            return result;
        }
    }
}
