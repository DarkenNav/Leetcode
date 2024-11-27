using Leetcode._Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    // 2601. Prime Subtraction Operation
    public class PrimeSubtractionOperationCase
        : IArrayLC, IMathLC, IBinarySearchLC, IGreedyLC, INumberTheoryLC
    {
        public void Cases()
        {
            // Output: true
            var result_0 = PrimeSubOperation([4, 9, 6, 10]);
            // Output: true
            var result_1 = PrimeSubOperation([6, 8, 11, 12]);
            // Output: false
            var result_2 = PrimeSubOperation([5, 8, 3]);
        }

        public bool PrimeSubOperation(int[] nums)
        {
            for(var i = 0; i < nums.Length; i++)
            {
                int bound;
                if (i == 0)
                    bound = nums[0];
                else
                    bound = nums[i] - nums[i - 1];

                if(bound <= 0)
                    return false;

                nums[i] = nums[i] - FindNearblyPrimeNumber(bound);
            }

            return true;
        }

        private int FindNearblyPrimeNumber(int target) 
        {
            for (var i = target - 1; i >= 2; i--)
            {
                if(IsPrimeNumber(i))
                    return i;
            }
            return 0;
        }

        private bool IsPrimeNumber(int n)
        {
            var sqrt = Math.Sqrt(n);
            for (var i = 2; i <= sqrt; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

    }
}
