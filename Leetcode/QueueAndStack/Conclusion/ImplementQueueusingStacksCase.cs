
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack.Conclusion
{
    public class ImplementQueueusingStacksCase 
    {
        public class MyQueue
        {
            private List<int> queue;
            public int Count { get; private set; }

            public MyQueue()
            {
                queue = new List<int>();
                Count = 0;
            }

            public void Push(int x)
            {
                queue.Add(x);
                Count++;
            }

            public int Pop()
            {
                if (Count > 0)
                {
                    var result = queue[0];
                    queue.RemoveAt(0);
                    Count--;
                    return result;
                }
                throw new Exception("Empty queue");
            }

            public int Peek()
            {
                if (Count > 0)
                    return queue[0];

                throw new Exception("Empty queue");
            }

            public bool Empty()
            {
                return Count <= 0;
            }
        }

        public void Case()
        {
            MyQueue myQueue = new MyQueue();
            myQueue.Push(1); // queue is: [1]
            myQueue.Push(2); // queue is: [1, 2] (leftmost is front of the queue)
            var result_0_0 = myQueue.Peek(); // return 1
            var result_0_1 = myQueue.Pop(); // return 1, queue is [2]
            var result_0_2 = myQueue.Empty(); // return false

            MyQueue obj = new MyQueue();
            obj.Push(8);
            int param_2 = obj.Pop();
            int param_3 = obj.Peek();
            bool param_4 = obj.Empty();
        }
    }
}
