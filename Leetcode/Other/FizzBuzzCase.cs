using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Other
{
    public class FizzBuzzCase
    {
        public void Cases()
        {
            var result_0 = FizzBuzz(3);
            var result_1 = FizzBuzz(5);
            var result_2 = FizzBuzz(15);

        }

        public IList<string> FizzBuzz(int n)
        {
            var result = new string[n];
            for (var i = 1; i < n+1; i++) { 
                var divBy3 = i % 3 == 0;
                var divBy5 = i % 5 == 0;

                if (divBy3 && divBy5)
                    result[i-1] = "FizzBuzz";
                else if (divBy3)
                    result[i-1] = "Fizz";
                else if (divBy5)
                    result[i-1] = "Buzz";
                else
                    result[i-1] = i.ToString();
            }
            return result;
        }
    }
}
