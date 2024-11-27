using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Trie
{
    // 386. Lexicographical Numbers
    public class LexicographicalNumbersCase
    {
        public void Cases()
        {
            //1,10,11,12,13,2,3,4,5,6,7,8,9
            var result_0 = LexicalOrder(13);
            //1,2
            var result_1 = LexicalOrder(2);
        }

        // грубая сила --------------------------------------------------
        public IList<int> LexicalOrder_1(int n)
        {
            var result = new List<string>();
            for(var i = 1; i <= n; i++)
            {
                result.Add(i.ToString());
            }

            return result
                .Order()
                .Select(x => int.Parse(x))
                .ToArray();
        }

        // Подход 2: Итеративный подход -----------------------------------------------------
        public IList<int> LexicalOrder(int n)
        {
            var result = new int[n];

            var currentNumber = 1;
            result[0] = currentNumber;
            var i = 1;
            while (i < n)
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

                result[i] = currentNumber;
                i++;
            }

            return result;
        }
    }
}
