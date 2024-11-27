using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch.Conclusion
{
    public class FindSmallestLetterGreaterThanTargetCase
    {
        public void Cases()
        {
            // "c"
            var result_0 = NextGreatestLetter(letters : ['c', 'f', 'j'], target : 'a');
            // "f"
            var result_1 = NextGreatestLetter(letters: ['c', 'f', 'j'], target: 'c');
            // "x"
            var result_2 = NextGreatestLetter(letters: ['x', 'x', 'y', 'y'], target: 'z');
            // "f"
            var result_3 = NextGreatestLetter(new char[] { 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'n', 'n', 'n', 'n' }, 'n');
        }

        public char NextGreatestLetter(char[] letters, char target)
        {
            var left = 0;
            var right = letters.Length;

            while (left < right)
            {
                var mid = left + (right - left) / 2;
                var compare = letters[mid].CompareTo(target);

                if (compare > 0)
                    right = mid;
                else 
                    left = mid + 1;
            }

            if (left < 0 || left >= letters.Length)
                return letters[0];

            return letters[left];
        }
    }
}
