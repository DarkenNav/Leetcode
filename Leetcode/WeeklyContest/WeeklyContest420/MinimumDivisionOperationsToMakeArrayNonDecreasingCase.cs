using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Leetcode.WeeklyContest.WeeklyContest420
{
    public class MinimumDivisionOperationsToMakeArrayNonDecreasingCase
    {
        public void Cases()
        {
            //var a0 = Divisors(769129, out List<int> divs);

            // Output: 1
            var result_0 = MinOperations([25, 7]);
            // Output: -1
            var result_1 = MinOperations([7, 7, 6]);
            // Output: 0
            var result_2 = MinOperations([1, 1, 1, 1]);
            // Output: 0
            var result_3 = MinOperations([7, 13]);
            // Output: 1
            var result_4 = MinOperations([240, 2, 11]);
            // Output: -1
            var result_5 = MinOperations([9, 2]);
            // Output: 4
            var result_6 = MinOperations([9, 27, 81, 27, 3]); 
        }

        // Any positive divisor of a natural number x that is
        // strictly less than x is called a proper divisor of x.
        // For example, 2 is a proper divisor of 4,
        // while 6 is not a proper divisor of 6.
        public int MinOperations(int[] nums)
        {
            var count = 0;
            var mem = new Dictionary<int, int>();
            for (var i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] == 1)
                    continue;
                
                if (nums[i] > nums[i + 1])
                {
                    var from = nums[i] / 2;
                    if (mem.ContainsKey(nums[i]))
                        from = mem[nums[i]];

                    for (var j = from; j > 1; j--)
                    {
                        if(nums[i] % j == 0)
                        {
                            var num = nums[i] / j;
                            if (num <= nums[i + 1])
                            {
                                mem[nums[i]] = j;
                                nums[i] = num;
                                count++;
                                break;
                            }
                        }
                    }
                }
                
                if (nums[i] > nums[i + 1])
                    return -1;
            }
            return count;
        }

        private bool Divisors(int num, out List<int> divs)
        {
            divs = new List<int>();
            var count = 0;
            for(var i = num / 2; i > 1; i--)
            {
                if (num % i == 0)
                {
                    divs.Add(i);
                }
                count++;
            }
            return divs.Count > 0;
        }
    }
}
