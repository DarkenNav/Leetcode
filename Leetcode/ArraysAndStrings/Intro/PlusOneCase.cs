
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class PlusOneCase 
    {
        public void Case()
        {
            var result1 = PlusOne(new int[] { 1, 2, 3 });
            var result2 = PlusOne(new int[] { 4, 3, 2, 1 });
            var result3 = PlusOne(new int[] { 9 });
        }

        public int[] PlusOne(int[] digits)
        {
            var digitsLenght = digits.Length;
            var digitsIndex = digitsLenght - 1;
            while (digitsIndex >= 0)
            {
                if (digits[digitsIndex] == 9)
                {
                    digits[digitsIndex] = 0;
                    digitsIndex--;
                }
                else
                {
                    digits[digitsIndex]++;
                    break;
                }
            }

            if (digitsIndex == -1)
            {
                var result = new int[digitsLenght + 1];
                result[0] = 1;
                Array.Copy(digits, 0, result, 1, digitsLenght);
                return result;
            }

            return digits;
        }
    }
}
