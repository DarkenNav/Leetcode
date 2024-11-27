
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class ReverseStringCase
    {
        public void Case()
        {
            ReverseString(new char[] { 'h', 'e', 'l', 'l', 'o' });
            ReverseString(new char[] { 'H', 'a', 'n', 'n', 'a', 'h' });
        }

        public void ReverseString(char[] s)
        {
            var i = 0;
            var j = s.Length - 1;
            while (i < j)
            {
                var temp = s[i]; 
                s[i] = s[j]; 
                s[j] = temp;
                i++;
                j--;
            }
        }
    }
}
