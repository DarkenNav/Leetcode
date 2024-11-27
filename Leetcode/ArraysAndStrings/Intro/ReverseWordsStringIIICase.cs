
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class ReverseWordsStringIIICase 
    {
        public void Case()
        {
            var result1 = ReverseWords("Let's take LeetCode contest");
            var result2 = ReverseWords("Mr Ding");
        }

        public string ReverseWords(string s)
        {
            var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var length = words.Length;
            for (int i = 0; i < length; i++)
            {
                words[i] = ReverseWord(words[i]);
            }
            return string.Join(' ', words);
        }

        public string ReverseWord(string word)
        {
            var arr = word.ToArray();
            var i = 0;
            var j = arr.Length - 1;
            while (i < j)
            {
                var temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                i++;
                j--;
            }
            return string.Join("", arr);
        }
    }
}
