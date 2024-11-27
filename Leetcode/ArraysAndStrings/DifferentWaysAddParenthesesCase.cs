using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    // 241. Different Ways to Add Parentheses
    public class DifferentWaysAddParenthesesCase
    {
        public void Cases()
        {
            var result = DiffWaysToCompute("2-1-1");
        }

        public IList<int> DiffWaysToCompute(string expression)
        {
            var result = new List<int>();
            if(string.IsNullOrEmpty(expression))
                return result;

            if(expression.Length == 1)
            {
                result.Add(int.Parse(expression));
                return result;
            }

            if (expression.Length == 2 && '0' <= expression[0] && expression[0] <= '9')
            {
                if (int.TryParse(expression, out int num))
                {
                    result.Add(num);
                }
                return result;
            }

            for (int i = 0; i < expression.Length; i++)
            {
                if ('0' <= expression[i] && expression[i] <= '9')
                    continue;

                var leftResult = DiffWaysToCompute(expression[..i]);
                var rightResult = DiffWaysToCompute(expression[(i + 1)..]);

                result.AddRange(CompleteOperation(leftResult, rightResult, expression[i]));
            }
            return result;
        }

        private IList<int> CompleteOperation(IList<int> left, IList<int> right, char exp)
        { 
            var result = new List<int>();
            foreach (var leftValue in left)
            {
                foreach (var rightValue in right)
                {
                    var computedResult = 0;
                    switch (exp)
                    {
                        case '+':
                            computedResult = leftValue + rightValue;
                            break;
                        case '-':
                            computedResult = leftValue - rightValue;
                            break;
                        case '*':
                            computedResult = leftValue * rightValue;
                            break;
                    }
                    result.Add(computedResult);
                }
            }
            return result;
        }
    }
}
