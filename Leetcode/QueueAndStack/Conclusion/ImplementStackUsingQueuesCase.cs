
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.QueueAndStack.Conclusion.ImplementStackUsingQueuesCase;

namespace Leetcode.QueueAndStack.Conclusion
{
    public class ImplementStackUsingQueuesCase 
    {
        public class MyStack
        {
            private List<int> stack;

            public MyStack()
            {
                stack = new List<int>();
            }

            public void Push(int x)
            {
                stack.Add(x);
            }

            public int Pop()
            {
                if (stack.Count > 0)
                {
                    var result = stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);
                    return result;
                }
                throw new Exception("Empty stack");
            }

            public int Top()
            {
                if (stack.Count > 0)
                    return stack[stack.Count - 1];

                throw new Exception("Empty stack");
            }

            public bool Empty()
            {
                return stack.Count <= 0;
            }
        }

        public void Case()
        {
            MyStack myStack = new MyStack();
            myStack.Push(1);
            myStack.Push(2);
            var result_0_0 = myStack.Top(); // return 2
            var result_0_1 = myStack.Pop(); // return 2
            var result_0_2 = myStack.Empty(); // return False
            var result_0_3 = myStack.Pop(); // return 2
            var result_0_4 = myStack.Empty(); // return False

        }
    }
}
