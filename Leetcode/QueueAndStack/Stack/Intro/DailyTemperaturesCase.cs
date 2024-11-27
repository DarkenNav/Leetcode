
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack.Stack.Intro
{
    public class DailyTemperaturesCase 
    {
        public void Case()
        {
            // 1,1,4,2,1,1,0,0
            var res_0 = DailyTemperatures(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 });
            // 1,1,1,0
            var res_1 = DailyTemperatures(new int[] { 30, 40, 50, 60 });
            // 1,1,0
            var res_2 = DailyTemperatures(new int[] { 30, 60, 90 });
        }

        public int[] DailyTemperatures(int[] temperatures)
        {
            var length = temperatures.Length;
            var result = new int[length];
            var stack = new Stack<(int, int)>();

            for (int i = 0; i < length; i++)
            {
                if (stack.Count > 0)
                {
                    while (stack.Count > 0)
                    {
                        if (stack.Peek().Item2 < temperatures[i])
                        {
                            var last = stack.Pop();
                            result[last.Item1] = i - last.Item1;
                        }
                        else
                            break;
                    }
                    stack.Push((i, temperatures[i]));
                }
                else
                {
                    stack.Push((i, temperatures[i]));
                }
            }
            return result;
        }
    }
}
