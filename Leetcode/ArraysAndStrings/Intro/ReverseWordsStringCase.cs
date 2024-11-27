
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class ReverseWordsStringCase 
    {
        public void Case()
        {
            var result1 = ReverseWords("the sky is blue");
            var result2 = ReverseWords("  hello world  ");
            var result3 = ReverseWords("a good   example");
        }

        public string ReverseWords(string s)
        {
            var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var i = 0;
            var j = words.Length - 1;
            while (i < j)
            {
                var temp = words[i];
                words[i] = words[j];
                words[j] = temp;
                i++;
                j--;
            }

            return string.Join(' ', words);
        }
    }
}
