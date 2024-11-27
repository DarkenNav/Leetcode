
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkedList.Intro
{
    public class RotateLinkedListCase 
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

            public List<int> ToListValue()
            {
                var list = new List<int>();
                var cursor = this;
                while (cursor != null)
                {
                    list.Add(cursor.val);
                    cursor = cursor.next;
                }
                return list;
            }
        }
        public void Case()
        {
            //var case0_head1 = new ListNode(new int[] { 1, 2, 3, 4, 5 }, 0);
            //var case0_result = RotateRight(case0_head1, 2);
            //var case0_list = case0_result?.ToListValue(); // 4,5,1,2,3

            //var case1_head1 = new ListNode(new int[] { 0, 1, 2 }, 0);
            //var case1_result = RotateRight(case1_head1, 4);
            //var case1_list = case1_result?.ToListValue(); // 2,0,1

            //var case2_result = RotateRight(null, 7);

            //var case3_head1 = new ListNode(new int[] { 1, 2, 3 }, 0);
            //var case3_result = RotateRight(case3_head1, 2000000000);
            //var case3_list = case3_result?.ToListValue(); // 2,0,1

            var case4_head1 = new ListNode(new int[] { 1, 2 }, 0);
            var case4_result = RotateRight(case4_head1, 2);
            var case4_list = case4_result?.ToListValue(); // 2,0,1

        }

        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0)
                return head;

            var currentNode = head;
            var count = 0;
            var set = new List<ListNode>();
            while (currentNode != null)
            {
                set.Add(currentNode);
                currentNode = currentNode.next;
                count++;
            }

            var slow = count - (count > k ? k : k % count);
            if(slow == 0 || slow == count)
                return head;

            var newHead = set[slow];
            set.Last().next = head;
            set[slow - 1].next = null;
            return newHead;
        }
    }
}
