
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack.Stack.Intro
{
    public class MinStackCase 
    {
        public class MinStack
        {
            private List<int> stack;
            private int count;

            public MinStack()
            {
                stack = new List<int>();
                count = 0;
            }

            public void Push(int val)
            {
                stack.Add(val);
                count++;
            }

            public void Pop()
            {
                if (count > 0)
                {
                    stack.RemoveAt(count - 1);
                    count--;
                }
            }

            public int Top()
            {
                return stack.Last();
            }

            public int GetMin()
            {
                return stack.Min();
            }
        }

        public void Case()
        {
            MinStack minStack = new MinStack();
            //ar res_0_3 = minStack.GetMin(); // ?
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            var res_0_0 = minStack.GetMin(); // return -3
            minStack.Pop();
            var res_0_1 = minStack.Top();    // return 0
            var res_0_2 = minStack.GetMin(); // return -2

            MinStack obj = new MinStack();
            obj.Push(235234524);
            obj.Pop();
            int param_3 = obj.Top();
            int param_4 = obj.GetMin();
        }
    }
}
