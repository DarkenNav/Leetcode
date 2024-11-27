
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.QueueAndStack.Stack.Intro
{
    public class EvaluateReversePolishNotationCase 
    {
        public void Case()
        {
            // 9
            var result_0 = EvalRPN(new string[] { "2", "1", "+", "3", "*" });
            // 6
            var result_1 = EvalRPN(new string[] { "4", "13", "5", "/", "+" });
            // 22
            var result_2 = EvalRPN(new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" });
        }

        private int MathOperation(int a, int b, string operation)
        { 
            switch (operation)
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/": return a / b;
            }
            return 0;
        }

        public int EvalRPN(string[] tokens)
        {
            var length = tokens.Length;
            if(length == 1) 
                return int.Parse(tokens[0]);

            var stack = new Stack<int>();
            var result = 0;
            for(var i = 0; i < length; i++)
            {
                if(stack.Count > 1)
                {
                    if (int.TryParse(tokens[i], out int value))
                    {
                        stack.Push(value);
                    }
                    else
                    {
                        var second = stack.Pop();
                        var first = stack.Pop();
                        result = MathOperation(first, second, tokens[i]);
                        stack.Push(result);
                    }
                }
                else
                {
                    stack.Push(int.Parse(tokens[i])); 
                }
            }

            return result;   
        }
    }
}
