using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Strings
{
    // 2490. Circular Sentence
    public class CircularSentenceCase
    {
        public void Cases()
        {
            // Output: true
            var result_0 = IsCircularSentence("leetcode exercises sound delightful");
            // Output: true
            var result_1 = IsCircularSentence("eetcode");
            // Output: false
            var result_2 = IsCircularSentence("Leetcode is cool");
        }

        public bool IsCircularSentence(string sentence)
        {
            var n = sentence.Length;
            if (sentence[0] != sentence[n - 1])
                return false;

            for (var i = 0; i < n; i++)
            {
                if (sentence[i] == ' ' && sentence[i-1] != sentence[i + 1])
                    return false;
            }

            return true;
        }
    }
}
