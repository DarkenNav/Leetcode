using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Strings
{
    // 796. Rotate String
    public class RotateStringCase
    {
        public void Cases()
        {
            // Output: true
            var result_0 = RotateString("abcde", "cdeab");
            // Output: false
            var result_1 = RotateString("abcde", "abced");
        }

        public bool RotateString(string s, string goal)
        {
            if(s.Length != goal.Length) 
                return false;

            var ss = s + s;
            return ss.Contains(goal);
        }
    }
}
