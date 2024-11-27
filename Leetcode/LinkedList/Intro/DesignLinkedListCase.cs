
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkedList.Intro
{
    public class DesignLinkedListCase 
    {
        public void Case()
        {
            //var list1 = new MyLinkedList();
            //var testCase1 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //for(var i = 0; i < testCase1.Length; i++)
            //{
            //    list1.AddAtTail(testCase1[i]);
            //}
            //var testGet = list1.Get(8);
            //list1.AddAtHead(20);
            //list1.AddAtTail(30);
            //list1.AddAtIndex(5, 40);
            //list1.DeleteAtIndex(0);

            //var list2 = new MyLinkedList();
            //list2.AddAtHead(1);
            //list2.AddAtTail(3);
            //list2.AddAtIndex(1, 2);
            //var list2Get1= list2.Get(1);
            //list2.DeleteAtIndex(1);
            //var list2Get2 = list2.Get(1);

            //var list3 = new MyLinkedList();
            //list3.AddAtHead(1);
            //list3.AddAtTail(3);
            //list3.AddAtIndex(1, 2);
            //var list3Get1 = list3.Get(1);
            //list3.DeleteAtIndex(0);
            //var list3Get2 = list3.Get(0);

            var list4 = new MyLinkedList();
            list4.AddAtIndex(1, 0);
            var list4Get1 = list4.Get(0);

        }
    }

    public class MyLinkedListNode
    { 
        public int Val { get; set; }
        public MyLinkedListNode? Next  { get; set; }

        public MyLinkedListNode()
        {
        }

        public MyLinkedListNode(int val)
        {
            Val = val;
        }
    }

    public class MyLinkedList
    {
        private MyLinkedListNode? head;

        public MyLinkedList()
        {
        }

        public int Get(int index)
        {
            var node = GetNode(index);
            return node != null ? node.Val : -1;
        }

        public MyLinkedListNode? GetLast()
        {
            var node = head;
            while (node != null && node?.Next != null)
            {
                node = node.Next;
            }
            return node;
        }

        public MyLinkedListNode? GetNode(int index)
        {
            var i = 0;
            var node = head;
            while (node != null && i < index)
            {
                if(node?.Next == null)
                {
                    node = null; 
                    break;
                }

                node = node?.Next;
                i++;
            }
            return node;
        }

        public void AddAtHead(int val)
        {
            var item = new MyLinkedListNode(val);
            if (head != null)
            {
                item.Next = head;
            }
            head = item;
        }

        public void AddAtTail(int val)
        {
            var last = GetLast();
            if (last == null)
            {
                AddAtHead(val);
            }
            else
            {
                var item = new MyLinkedListNode(val);
                last.Next = item;
            }
        }

        public void AddAtIndex(int index, int val)
        {
            var item = new MyLinkedListNode(val);
            if (index <= 0)
            {
                item.Next = head;
                head = item;
                return;
            }

            var prev = GetNode(index - 1);
            if (prev == null)
            {
                return;
            }

            if(prev.Next == null)
            {
                prev.Next = item;
                return;
            }

            item.Next = prev.Next;
            prev.Next = item;
            
        }

        public void DeleteAtIndex(int index)
        {
            if(index == 0)
            {
                if(head.Next != null)
                {
                    head = head.Next;
                }
                else
                {
                    head = null;
                }
                return;
            }

            var prevTarget = GetNode(index - 1);
            if (prevTarget != null)
            {
                if(prevTarget.Next != null)
                {
                    if (prevTarget?.Next?.Next != null)
                    {
                        prevTarget.Next = prevTarget.Next.Next;
                    }
                    else
                    {
                        prevTarget.Next = null;
                    }
                }
            }
        }
    }
}
