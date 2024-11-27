using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack
{
    // 1381. Design a Stack With Increment Operation
    public class DesignStackWithIncrementOperationCase
    {
        public void Cases()
        {
            var maxSize = 3;
            CustomStack stk = new CustomStack(maxSize);
            stk.Push(1);              // stack becomes [1]
            stk.Push(2);              // stack becomes [1, 2]
            var result_0 = stk.Pop(); // return 2 --> Return top of the stack 2, stack becomes [1]
            stk.Push(2);              // stack becomes [1, 2]
            stk.Push(3);              // stack becomes [1, 2, 3]
            stk.Push(4);              // stack still [1, 2, 3], Do not add another elements as size is 4
            stk.Increment(5, 100);    // stack becomes [101, 102, 103]
            stk.Increment(2, 100);    // stack becomes [201, 202, 103]
            var result_1 = stk.Pop(); // return 103 --> Return top of the stack 103, stack becomes [201, 202]
            var result_2 = stk.Pop(); // return 202 --> Return top of the stack 202, stack becomes [201]
            var result_3 = stk.Pop(); // return 201 --> Return top of the stack 201, stack becomes []
            var result_4 = stk.Pop();
        }

        public class CustomStack
        {
            private int?[] stack;
            private int last;

            // Инициализирует объект, содержащий maxSizeмаксимальное количество
            // элементов в стеке.
            public CustomStack(int maxSize)
            {
                stack = new int?[maxSize];
                last = -1;
            }

            // Добавляет xк вершине стека, если стек не достиг maxSize.
            public void Push(int x)
            {
                if (last + 1 >= stack.Length)
                    return;
                last++;
                stack[last] = x;
            }

            // Извлекает и возвращает вершину стека или -1 если стек пуст.
            public int Pop()
            {
                if(last < 0)
                    return -1;
                var item = stack[last] ?? -1;
                stack[last] = null;
                last--;
                return item;
            }

            // Увеличивает нижние k элементы стека на val.
            // Если в стеке меньше k элементов, то увеличиваются все элементы в стеке.
            public void Increment(int k, int val)
            {
                for(var i = 0; i < k && i <= last && i < stack.Length; i++)
                {
                    stack[i] += val;
                }
            }
        }
    }
}
