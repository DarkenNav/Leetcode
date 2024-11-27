using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Reqursion.Intro
{
    public class FibonacciNumberCase
    {
        public void Cases()
        {
            var result_0 = Fib(2);
            var result_1 = Fib(3);
            var result_2 = Fib(4);
        }

        public int Fib(int n)
        {
            if(n == 0) return 0;
            if(n == 1) return 1;

            return Fib(n - 1) + Fib(n - 2);
        }
    }
}
