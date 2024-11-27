using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Strings
{
    public class LongestHappyStringCase
    {
        //Строка sназывается счастливой, если она удовлетворяет следующим условиям:
        //s - содержит только буквы 'a', 'b', и 'c'.
        //s - не содержит ни одного из "aaa", "bbb"или "ccc"в качестве подстроки.
        //s - содержит не более 1000 a вхождений буквы 'a'.
        //s - содержит не более 1000 b вхождений буквы 'b'.
        //s - содержит не более 1000 c вхождений буквы 'c'.

        public void Cases()
        {
            var result_01 = LongestDiverseString(10, 3, 3);

            // Output: "ccaccbcc"
            // «ccbccacc» также будет правильным ответом.
            var result_0 = LongestDiverseString(1, 1, 7);
            // Output: "aabaa"
            // Это единственный правильный ответ в данном случае.
            var result_1 = LongestDiverseString(7, 1, 0);
        }

        // Решение с приоритетной очередью
        public string LongestDiverseString(int a, int b, int c)
        {
            var pq = new PriorityQueue<char, int>(
                Comparer<int>.Create((x, y) => y - x));
            if (a > 0) pq.Enqueue('a', a);
            if (b > 0) pq.Enqueue('b', b);
            if (c > 0) pq.Enqueue('c', c);

            var s = new StringBuilder();
            while (pq.Count > 0)
            {
                _ = pq.TryDequeue(out var ch, out var count);
                var n = s.Length;
                if (n >= 2 && s[n - 1] == ch && s[n - 2] == ch)
                {
                    if (pq.Count == 0) break;
                    _ = pq.TryDequeue(out var ch1, out var count1);
                    s.Append(ch1);
                    if(count1 - 1 > 0)
                        pq.Enqueue(ch1, count1 - 1);
                }
                else
                {
                    count--;
                    s.Append(ch);
                }

                if(count > 0)
                    pq.Enqueue(ch, count);
            }

            return s.ToString();
        }

        // Мое решение
        private char GetChar(int a, int b, int c)
        {
            if (a > 0 && a >= b && a >= c)
                return 'a';
            else if (b > 0 && b >= c && b >= a)
                return 'b';
            else if (c > 0 && c >= a && c >= b)
                return 'c';
            return 'z';

        }

        public string LongestDiverseString_1(int a, int b, int c)
        {
            var n = a + b + c;
            var s = new StringBuilder();
            var max_a = 0;
            var max_b = 0;
            var max_c = 0;
            var curr = 'z';
            while (n > 0)
            {
                if (max_a > 1)
                    curr = GetChar(0, b, c);
                else if (max_b > 1)
                    curr = GetChar(a, 0, c);
                else if (max_c > 1)
                    curr = GetChar(a, b, 0);
                else
                    curr = GetChar(a, b, c);

                if (curr == 'a')
                {
                    a--;
                    max_a++;
                    max_b = max_c = 0;
                }
                else if(curr == 'b')
                {
                    b--;
                    max_b++;
                    max_a = max_c = 0;
                }
                else if(curr == 'c')
                {
                    c--;
                    max_c++;
                    max_a = max_b = 0;
                }
                else
                    break;

                s.Append(curr);
                n--;
            }

            return s.ToString();
        }
    }
}
