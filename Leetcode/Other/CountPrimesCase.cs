using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Other
{
    public class CountPrimesCase
    {
        // Решето Эратосфена
        public void Cases()
        {
            // Output: 4
            var result_0 = CountPrimes(10);
            // Output: 0
            var result_1 = CountPrimes(0);
            // Output: 0
            var result_2 = CountPrimes(1);
            // Output: 1
            var result_3 = CountPrimes(3);
        }

        public int CountPrimes(int n)
        {
            if (n < 2) return 0;
            var A = new bool[n];
            for (var i = 2; i * i <= n; ++i)
            {
                if (!A[i])
                {
                    for (var j = i * i; j < n; j += i)
                    {
                        A[j] = true;
                    }
                }
            }
            return A[2..].Count(x => !x);
        }

        public int CountPrimes_1(int n)
        {
            if (n < 2) return 0;
            var A = new bool[n];
            for (var i = 2; i < n; i++) 
            { 
                A[i] = true; 
            }

            for (var i = 2; i * i <= n; ++i)
            {
                if (A[i])
                {
                    for (var j = i * i; j < n; j += i)
                    {
                        A[j] = false;
                    }
                }
            }
            var count = 0;
            for(var i = 2; i < n; i++)
            {
                if(A[i])
                    count++;
            }

            return count;
        }
    }
}
