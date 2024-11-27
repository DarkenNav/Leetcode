
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack.Stack.Intro
{
    public class ValidParenthesesCase 
    {
        public void Case()
        {
            var res_0 = IsValid("()");      // True
            var res_1 = IsValid("()[]{}");  // True
            var res_2 = IsValid("(]");      // False
            var res_3 = IsValid("([])");    // True
            var res_4 = IsValid("([)");      // False
            var res_5 = IsValid("(");      // False
        }

        private bool CheckBracket(char openBracket, char closeBracket)
        {
            //()[]{}
            if(openBracket == '(' && closeBracket == ')')
                return true;
            if (openBracket == '[' && closeBracket == ']')
                return true;
            if (openBracket == '{' && closeBracket == '}')
                return true;

            return false;
        }

        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            var length = s.Length;
            for (var i = 0; i < length; i++)
            {
                if (stack.Count > 0)
                { 
                    if(CheckBracket(stack.Peek(), s[i]))
                        stack.Pop();
                    else
                        stack.Push(s[i]);
                }
                else
                {
                    stack.Push(s[i]);
                }
            }
            if (stack.Count > 0)
                return false;

            return true;
        }
    }
}
