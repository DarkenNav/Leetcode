using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.DataStruct101
{
    public class SquaresOfSortedArrayCase
    {
        public void Cases()
        {
            var result_01 = SortedSquares([4]);

            // Output: [0,1,9,16,100]
            var result_0 = SortedSquares([-4, -1, 0, 3, 10]);
            // Output: [4,9,9,49,121]
            var result_1 = SortedSquares([-7, -3, 2, 3, 11]);
        }

        // -- O(log n)
        public int[] SortedSquares_0(int[] nums)
        {
            var n = nums.Length;
            var result = new int[n];
            var left = 0;
            var right = n - 1;
            while(left < right && n >= 0)
            {              
                if (Math.Abs(nums[left]) == Math.Abs(nums[right]))
                {
                    result[n-1] = result[n-2] = nums[left] * nums[left];
                    left++;
                    right--;
                    n -= 2;                    
                }
                else if(Math.Abs(nums[left]) < Math.Abs(nums[right]))
                {
                    result[n-1] = nums[right] * nums[right];
                    right--; 
                    n--;
                }
                else
                {
                    result[n-1] = nums[left] * nums[left];
                    left++;
                    n--;
                }
            }

            if(left == right)
            {
                result[0] = nums[left] * nums[left];
            }

            return result;
        }

        // -- O(n)
        public int[] SortedSquares(int[] nums)
        {
            var n = nums.Length;
            var posCount = 0;
            var negCount = 0;
            for(var i = 0; i < n; i++)
            {
                if (nums[i] >= 0)
                    posCount++;
                else
                    negCount++;

                nums[i] *= nums[i];
            }

            var result = new int[n];
            var pos = n - 1;
            var neg = 0;
            for (var i = n - 1; i >= 0; i--) 
            { 
                if (pos >= 0 && neg < negCount)
                {
                    if (nums[neg] > nums[pos])
                    {
                        result[i] = nums[neg];
                        neg++;
                    }
                    else
                    {
                        result[i] = nums[pos];
                        pos--;
                    }
                }
                else if(neg < negCount)
                {
                    result[i] = nums[neg];
                    neg++;
                }                
                else
                {
                    result[i] = nums[pos];
                    pos--;
                }
            }

            return result;
        }

        // -- for O(n) sort O(n^2)
        public int[] SortedSquares_1(int[] nums)
        {
            var n = nums.Length;
            var result = new int[n];
            for(var i = 0; i < n; i++)
            {
                result[i] = nums[i] * nums[i];
            }
            Array.Sort(result);
            return result;
        }
    }
}
