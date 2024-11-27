using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode._Examples.Aync
{
    public class ConsoleDrawSomesing
    {
        private static int left = 0;
        private static int top = 3;

        public static void StartMoveAsync()
        {
            Thread.Sleep(99);
            Console.SetCursorPosition(left, top);
            for (int i = 0; i < 80; i++)
            {
                Console.Write("*");
            }

            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(99);
                    Console.SetCursorPosition(left, top);
                    Console.Write(">");

                    if(left + 1 > 79)
                    {
                        left = 0;
                    }
                    else
                    {
                        left++;
                    }
                }
            });
        }

        public static void ClockAsync()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Console.SetCursorPosition(37, 1);
                    Console.Write($"{DateTime.Now.ToString("HH:mm:ss")}");
                    Thread.Sleep(1000);
                }
            });
        }

    }
}
