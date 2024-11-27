using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    // 921. Minimum Add to Make Parentheses Valid
    public class MinimumAddMakeParenthesesValidCase
    {
        public void Cases()
        {
            // Output: 1
            var result_0 = MinAddToMakeValid("())");
            // Output: 3
            var result_1 = MinAddToMakeValid("(((");
            var result_11 = MinAddToMakeValid(")))");

            var result_2 = MinAddToMakeValid("()))((");
            var result_3 = MinAddToMakeValid(")())((()()()))((((()()())))())))((())())())()())(()))((()(((((())((()()()(((((()(((((())(((()(()((((((())(())))))))(((((((())())))(())())))()(()())))())()))))()())())(()()()()))())((())()((((())()()()()()())()()()))())))(())))))()())(()())(())))()((()()(())((()(((()())()((())((()()()))())((()())(()(()))(()((()(()()((()()())()))))(()()()()))(((()((())((()(()(())(((()(()()()()(()()((()))((()))()())()())(()(())))((()()()(()(()()))))())((((())())(())(()((((()))(()((())()))))))()()))(((((()((()()((()(())))))()(()))(()()((()()))))()))((((()()()()(()))()(())))())))())))((()())()(())()(()()(()(())(((((())((((())(((((()())())))(()(()()()()()((((()()(((()))())((((()())(((())))()))((()))))())()(()())()))(()())((()(()))(())()(()((())(()))))))))()))(()(())))(()()()(((()((())()((()()()((((((()))()((())))(()())())()(((((()(()()()(())()())(())(()((((()(())(()())()()())(((())(())()())())(())))()))))))()()))(())))(((()))((())(((())((()(((((())(())(()((())))()))())(((((((()(((())()))))(((((((((()))(()(((");
        }

        public int MinAddToMakeValid(string s)
        {
            var n = s.Length;
            var openCount = 0;
            var result = 0;
            for(var i = 0; i < n; i++)
            {
                if (s[i] == ')' && openCount == 0)
                {
                    result++;
                    continue;
                }

                if (s[i] == '(')
                    openCount++;
                else
                    openCount--;
            }
            
            return result + openCount;
        }
    }
}
