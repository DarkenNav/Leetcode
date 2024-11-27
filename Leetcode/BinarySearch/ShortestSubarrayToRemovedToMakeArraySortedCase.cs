using Leetcode._Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    public class ShortestSubarrayToRemovedToMakeArraySortedCase
        : IArrayLC, ITwoPointersLC, IBinarySearchLC, IStackLC, IMonotonicStackLC
        {
            // 1574. Shortest Subarray to be Removed to Make Array Sorted
            public void Cases()
            {
                // Output: 3
                var result_0 = FindLengthOfShortestSubarray([1,2,3,10,4,2,3,5]);
            }

            public int FindLengthOfShortestSubarray(int[] arr) {
                var n = arr.Length;
                var right = n - 1;
                while(right > 0 && arr[right] >= arr[right-1])
                {
                    right--;
                }

                var result = right;
                var left = 0;
                while(left < right && (left == 0 || arr[left-1] <= arr[left]))
                {
                    while(right < n && arr[left] > arr[right])
                    {
                        right++;
                    }
                    result = Math.Min(result, right - left - 1);
                    left++;
                }

                return result;
            }
        }

}