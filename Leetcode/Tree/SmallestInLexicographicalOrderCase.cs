using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Trie
{
    // 440. K-th Smallest in Lexicographical Order
    public class SmallestInLexicographicalOrderCase
    {
        public void Cases()
        {
            //var result_0 = FindKthNumber(13, 2);
            //var result_1 = FindKthNumber(1, 1);

            // 416126219
            var result_2 = FindKthNumber(681692778, 351251360);
        }

        public int FindKthNumber_Try(int n, int k)
        {
            if (k == 1)
                return 1;
            if (n == 1)
                return 1;

            long currentNumber = 1;
            k--;
            while (k > 0)
            {
                if (currentNumber * 10 <= n)
                {
                    currentNumber *= 10;
                }
                else
                {
                    while (currentNumber % 10 == 9 || currentNumber >= n)
                    {
                        currentNumber /= 10;
                    }
                    currentNumber += 1;
                }
                k--;
            }
            return (int)currentNumber;
        }

        // Редакционная статья
        public int FindKthNumber(int n, int k)
        {
            if (k == 1)
                return 1;
            if (n == 1)
                return 1;

            var current = 1;
            k--;
            while (k > 0)
            {
                int step = CountSteps(n, current, current + 1);

                if (step <= k)
                {
                    current++;
                    k -= step;
                }
                else
                {
                    current *= 10;
                    k--;
                }
            }

            return current;
        }

        private int CountSteps(int n, long prefix1, long prefix2)
        {
            long steps = 0;
            while (prefix1 <= n)
            {
                steps += Math.Min(n + 1, prefix2) - prefix1;
                prefix1 *= 10;
                prefix2 *= 10;
            }
            return (int)steps;
        }
    }
}
