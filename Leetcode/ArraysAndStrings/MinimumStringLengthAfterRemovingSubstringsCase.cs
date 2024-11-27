using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    public class MinimumStringLengthAfterRemovingSubstringsCase
    {
        public void Cases()
        {
            // Output: 2
            var result_0 = MinLength("ABFCACDB");
            // Output: 5
            var result_1 = MinLength("ACBBD");
        }

        public int MinLength(string s)
        {
            var target1 = "AB";
            var target2 = "CD";

            var stack = new Stack<string>();
            stack.Push(s);
            while (stack.Count > 0)
            {
                var s1 = stack.Pop();
                if (s1.Contains(target1))
                {
                    s1 = s1.Replace(target1, "");
                    stack.Push(s1);
                }
                else if(s1.Contains(target2))
                {
                    s1 = s1.Replace(target2, "");
                    stack.Push(s1);
                }
                else
                    return s1.Length;
            }

            return s.Length;
        }
    }
}
