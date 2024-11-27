using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch.Untro
{
    public class GuessNumberHigherOrLowerCase
    {
        public int pick { get; set; }
        public void Cases()
        {
            var n = 1000;
            pick = 175;

            var result = GuessNumber(n);
        }

        public int guess(int num)
        {
            if (num > pick)
                return -1;
            else if (num < pick)
                return 1;
            
            return 0;
        }

        public int GuessNumber(int n)
        {
            if (n == 1)
                return n;

            var left = 0;
            var right = n;
            while(left <= right)
            {
                var mid = left + (right - left) / 2;
                var _guess = guess(mid);

                if (_guess == -1)
                    right = mid - 1;
                else if (_guess == 1)
                    left = mid + 1;
                else
                    return mid;
            }
            return -1;
        }
    }
}
