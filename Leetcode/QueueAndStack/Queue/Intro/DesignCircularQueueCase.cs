

namespace Leetcode.QueueAndStack.Queue.Intro
{
    public class DesignCircularQueueCase 
    {
        public class MyCircularQueue
        {
            private readonly int?[] queue;
            private int head;
            private int tail;
            private int length;

            public MyCircularQueue(int k)
            {
                length = k;
                queue = new int?[k];
                head = -1;
                tail = 0;
            }

            public bool EnQueue(int value)
            {
                if (queue[tail] != null)
                    return false;

                queue[tail] = value;
                tail++;
                if(tail >= length)
                    tail = 0;
                if(head == -1)
                    head = 0;

                return true;
            }

            public bool DeQueue()
            {
                if(head == -1)
                    return false;
                queue[head] = null;
                head++;
                if (head >= length)
                    head = 0;
                if (queue[head] == null)
                {
                    head = -1;
                    tail = 0;
                }

                return true;
            }

            public int Front()
            {
                return head != -1 ? queue[head].Value : -1;
            }

            public int Rear()
            {
                var rear = tail - 1 >= 0 ? tail - 1 : length - 1;
                return queue[rear] ?? -1;
            }

            public bool IsEmpty()
            {
                return head == -1;
            }

            public bool IsFull()
            {
                return tail == head;
            }
        }

        public void Case()
        {
            var myCircularQueue = new MyCircularQueue(3);
            var res0 = myCircularQueue.IsEmpty(); // return True
            var res1 = myCircularQueue.EnQueue(1); // return True
            var res2 = myCircularQueue.EnQueue(2); // return True
            var res0_1 = myCircularQueue.IsEmpty(); // return True
            var res3 = myCircularQueue.EnQueue(3); // return True
            var res4 = myCircularQueue.EnQueue(4); // return False
            var res5 = myCircularQueue.Rear();     // return 3
            var res5_1 = myCircularQueue.Front();     // return 1
            var res6 = myCircularQueue.IsFull();   // return True
            var res7 = myCircularQueue.DeQueue();  // return True
            var res5_2 = myCircularQueue.Front();     // return 2
            var res8 = myCircularQueue.EnQueue(4); // return True
            var res9 = myCircularQueue.Rear();     // return 4
            var res10 = myCircularQueue.DeQueue();  // return True
            var res11 = myCircularQueue.DeQueue();  // return True
            var res12 = myCircularQueue.DeQueue();  // return True
            var res13 = myCircularQueue.DeQueue();  // return False
            var res0_2 = myCircularQueue.IsEmpty(); // return True
            var res5_3 = myCircularQueue.Front();     // return -1
            var res15 = myCircularQueue.EnQueue(7); // return True
            var res16 = myCircularQueue.EnQueue(2000); // return True
            var res5_4 = myCircularQueue.Front();     // return 7

            var myCircularQueue2 = new MyCircularQueue(8);
            var res_0_0 = myCircularQueue2.EnQueue(3); // return True
            var res_0_1 = myCircularQueue2.EnQueue(9); // return True
            var res_0_2 = myCircularQueue2.EnQueue(5); // return True
            var res_0_3 = myCircularQueue2.EnQueue(0); // return True
            var res_0_4 = myCircularQueue2.DeQueue(); // return True
            var res_0_5 = myCircularQueue2.DeQueue(); // return True
            var res_0_6 = myCircularQueue2.IsEmpty(); // return False
            var res_0_7 = myCircularQueue2.IsEmpty(); // return False
            var res_0_8 = myCircularQueue2.Rear(); // return 0
            var res_0_9 = myCircularQueue2.Rear(); // return 0
            var res_0_10 = myCircularQueue2.DeQueue(); // return True

        }
    }
}
