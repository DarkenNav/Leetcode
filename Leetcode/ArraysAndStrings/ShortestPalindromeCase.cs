using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    // 214. Shortest Palindrome
    public class ShortestPalindromeCase
    {
        public void Cases()
        {
            // aacecaaa
            // aaacecaa
            // result aaacecaaa
            var return_0 = ShortestPalindrome("aacecaaa");
            //dcbabcd
            var return_1 = ShortestPalindrome("abcd");
        }

        // Подход 3: алгоритм КМП (Кнута-Морриса-Пратта) -----------------------------------
        public string ShortestPalindrome_3(string s)
        {
            var reversed = string.Join("", s.Reverse());
            var combinedString = new StringBuilder(s)
                .Append("#")
                .Append(reversed)
                .ToString();

            var prefixTab = BuildPrefixTable(combinedString);
            var palindromeLength = prefixTab[combinedString.Length - 1];

            var suffix = new StringBuilder(
                string.Join("", s.Substring(palindromeLength).Reverse()));

            return suffix.Append(s).ToString();
        }

        private int[] BuildPrefixTable(string s)
        {
            var prefixTable = new int[s.Length];
            var length = 0;
            for (int i = 1; i < s.Length; i++)
            {
                while (length > 0 && s[i] != s[length])
                {
                    length = prefixTable[length - 1];
                }
                if (s[i] == s[length])
                    length++;
                prefixTable[i] = length;
            }
            return prefixTable;
        }

        // Подход 2: Два указателя ---------------------------------------------------------------------
        public string ShortestPalindrome(string s)
        {
            if(string.IsNullOrEmpty(s))
                return s;

            var left = 0;
            for (var right = s.Length - 1; right >= 0; right--)
            {
                if (s[left] == s[right])
                    left++;
            }

            if(left == s.Length)
                return s;

            var notPalindrome = s.Substring(left);
            var reversed = new StringBuilder(string.Join("", notPalindrome.Reverse()));

            var shortest = ShortestPalindrome(s.Substring(0, left));
            reversed.Append(shortest);
            reversed.Append(notPalindrome);

            return reversed.ToString();
        }

        // Подход 1: Грубая сила ---------------------------------------------------------------------
        public string ShortestPalindrome_1(string s)
        {
            var reversed = string.Join("", s.Reverse());            
            for (var i = 0; i < s.Length; i++)
            {
                var sub = s.Substring(0, s.Length - i);
                var subReversed = reversed.Substring(i);
                if(sub.Equals(subReversed))
                {
                    var result = new StringBuilder();
                    result.Append(reversed.Substring(0, i));
                    result.Append(s);
                    return result.ToString();
                }
            }
            
            return string.Empty;
        }
    }
}
