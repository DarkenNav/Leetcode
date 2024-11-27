using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Strings
{
    public class ValidPalindromeCase
    {
        public void Cases()
        {
            //// Output: true
            //var result_0 = IsPalindrome("A man, a plan, a canal: Panama");
            //// Output: false
            //var result_1 = IsPalindrome("race a car");
            //// Output: true
            //var result_2 = IsPalindrome(" ");
            // Output: false
            var result_3 = IsPalindrome("9P");
        }

        public bool IsPalindrome(string s)
        {
            var left = 0;
            var right = s.Length - 1;
            while (left < right) 
            {
                var c1 = char.ToLower(s[left]);
                if (!IsAlphanumeric(c1))
                {
                    left++;
                    continue;
                }

                var c2 = char.ToLower(s[right]);
                if (!IsAlphanumeric(c2))
                {
                    right--;
                    continue;
                }

                if(c1 != c2)
                    return false;

                left++;
                right--;
            }

            return true;
        }

        private bool IsAlphanumeric(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9');
        }
    }
}
