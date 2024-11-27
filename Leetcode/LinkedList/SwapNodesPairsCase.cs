using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkedList
{
    public class SwapNodesPairsCase
    {
        
        public class ListNode 
        {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        } 

        public void Cases()
        {
            var node_0_3 = new ListNode(4);
            var node_0_2 = new ListNode(3, node_0_3);
            var node_0_1 = new ListNode(2, node_0_2);
            var node_0_0 = new ListNode(1, node_0_1);
            // [2,1,4,3]
            var result_0 = SwapPairs(node_0_0);

            // []
            var result_1 = SwapPairs(null);

            var node_2_0 = new ListNode(1);
            // [1]
            var result_2 = SwapPairs(node_2_0);

            var node_3_2 = new ListNode(3);
            var node_3_1 = new ListNode(2, node_3_2);
            var node_3_0 = new ListNode(1, node_3_1);
            // [2,1,3]
            var result_3 = SwapPairs(node_3_0);
        }

        public ListNode SwapPairs(ListNode head)
        {
            if (head == null)
                return null;

            if (head.next == null)
                return head;

            if (head.next.next != null && head.next.next.next != null)
                head.next.next = SwapPairs(head.next.next);

            var newHead = head.next;
            head.next = newHead.next;
            newHead.next = head;

            return newHead;
        }
    }
}
