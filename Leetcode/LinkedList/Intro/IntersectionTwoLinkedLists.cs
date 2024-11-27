

using System.Buffers.Text;

namespace Leetcode.LinkedList.Intro
{

    public class IntersectionTwoLinkedLists 
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
                if(begin + 1 < vals.Length)
                    next = new ListNode(vals, begin + 1);
            }

            public void AddToEnd(ListNode node)
            {
                if (next == null)
                {
                    next = node;
                } else
                {
                    var current = next;
                    while (current != null && current.next != null)
                    {
                        current = current.next;
                    }
                    current.next = node;
                }

            }
        }

        public void Case()
        {
            var case1_intersectVal = 8;
            var case1_skipA = 2;
            var case1_skipB = 3;
            var case1_headA = new ListNode(new int[] { 4, 1 }, 0);
            var case1_headB = new ListNode(new int[] { 5, 6, 1 }, 0);
            var case1_intersect = new ListNode(new int[] { 8, 4, 5 }, 0);
            case1_headA.AddToEnd(case1_intersect);
            case1_headB.AddToEnd(case1_intersect);
            var case1_result = GetIntersectionNode(case1_headA, case1_headB);

            var case2_intersectVal = 2;
            var case2_skipA = 3;
            var case2_skipB = 1;
            var case2_headA = new ListNode(new int[] { 1, 9, 1 }, 0);
            var case2_headB = new ListNode(new int[] { 3 }, 0);
            var case2_intersect = new ListNode(new int[] { 2, 4 }, 0);
            case2_headA.AddToEnd(case2_intersect);
            case2_headB.AddToEnd(case2_intersect);
            var case2_result = GetIntersectionNode(case2_headA, case2_headB);

            var case3_intersectVal = 0;
            var case3_skipA = 3;
            var case3_skipB = 2;
            var case3_headA = new ListNode(new int[] { 2, 6, 4 }, 0);
            var case3_headB = new ListNode(new int[] { 1, 5 }, 0);
            var case3_result = GetIntersectionNode(case3_headA, case3_headB);

            var case4_intersectVal = 1;
            var case4_skipA = 0;
            var case4_skipB = 0;
            var case4_headA = new ListNode(new int[] { 1 }, 0);
            var case4_headB = case4_headA;
            var case4_result = GetIntersectionNode(case4_headA, case4_headB);

            var case5_intersectVal = 3;
            var case5_skipA = 0;
            var case5_skipB = 1;
            var case5_headA = new ListNode(new int[] { 3 }, 0);
            var case5_headB = new ListNode(new int[] { 2 }, 0);
            case5_headB.AddToEnd(case5_headA);
            var case5_result = GetIntersectionNode(case5_headA, case5_headB);
        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == headB)
                return headA;

            var set = new HashSet<ListNode>();
            var nodeA = headA;
            set.Add(nodeA);
            while (nodeA != null && nodeA.next != null) 
            {
                set.Add(nodeA.next);
                nodeA = nodeA.next;
            }

            var nodeB = headB;
            while (nodeB != null)
            {
                if(set.Contains(nodeB))
                {
                    return nodeB;
                }
                if (nodeB.next == null)
                    break;

                nodeB = nodeB.next;
            }

            return null;
        }
    }
}
