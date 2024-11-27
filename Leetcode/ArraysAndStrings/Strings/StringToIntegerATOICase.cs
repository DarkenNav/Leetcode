using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Strings
{
    public class StringToIntegerATOICase
    {
        public void Cases()
        {
            // Output: 42
            var result_0 = MyAtoi("42");
            // Output: -42
            var result_1 = MyAtoi("-042");
            // Output: 1337
            var result_2 = MyAtoi("1337c0d3");
            // Output: 0
            var result_3 = MyAtoi("0-1");
            // Output: 0
            var result_4 = MyAtoi("words and 987");
            // Output: int.MinValue
            var result_5 = MyAtoi("-00000452354235423542352523523525234adfadsf");
            //Output: int.MinValue - 2147483648
            var result_6 = MyAtoi("-91283472332");
            //Output: 0
            var result_7 = MyAtoi("+-12");
            //Output: 0
            var result_8 = MyAtoi("");
            //Output: 0
            var result_9 = MyAtoi("20000000000000000000");
        }

        public int MyAtoi(string s)
        {
            var index = 0;
            while (index < s.Length && char.IsWhiteSpace(s[index]))
            {
                index++;
            }

            var sign = 1;
            if(index < s.Length && (s[index] == '-' || s[index] == '+'))
            {
                sign = s[index] == '-' ? -1 : 1;
                index++;
            }

            var result = 0;
            while(index < s.Length && char.IsDigit(s[index]))
            {
                var digit = s[index] - '0';
                if(result > (int.MaxValue - digit) / 10)
                {
                    return sign == -1 ? int.MinValue : int.MaxValue;
                }

                result = (result * 10) + digit;
                index++;
            }

            return result * sign;
        }

        public int MyAtoi_WithErrors(string s)
        {
            var str = new StringBuilder(s.TrimStart());
            if (str.Length == 0)
                return 0;

            var negative = 1;
            if (str[0] == '-' || str[0] == '+')
            {
                negative = str[0] == '-' ? -1 : 1;
                str.Remove(0, 1);
            }

            if (str.Length == 0)
                return 0;

            var cur = 0;
            while (cur < str.Length)
            {
                if (str[cur] >= '0' && str[cur] <= '9')
                {
                    cur++;
                }
                else
                {
                    break;
                }
            }

            if (str[0] < '0' && str[0] > '9')
                return 0;

            str.Remove(cur, str.Length - cur);

            cur = 0;
            while (cur < str.Length)
            {
                if (str[cur] == '0')
                {
                    cur++;
                }
                else
                {
                    break;
                }
            }

            if(cur > 0)
                str.Remove(0, cur);

            long result = 0;
            for(var i = str.Length - 1; i >= 0; i--)
            {
                result += long.Parse(str[i].ToString()) * (long)Math.Pow(10, str.Length - (i + 1));

                if (result >= int.MaxValue)
                    break;
            }

            if (result >= int.MaxValue)
            {
                if (negative == -1)
                {
                    if (result == int.MaxValue)
                        return negative * int.MaxValue;
                    else
                        return int.MinValue;
                }
                else
                    return int.MaxValue;
            }

            return (int)result * negative;
        }
    }
}
