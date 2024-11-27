using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    public class ValidMountainArrayCase
    {
        public void Cases()
        {
            // Output: false
            var result_0 = ValidMountainArray([2, 1]);
            // Output: false
            var result_1 = ValidMountainArray([3, 5, 5]);
            // Output: true
            var result_2 = ValidMountainArray([0, 3, 2, 1]);
            // Output: true
            var result_3 = ValidMountainArray([0, 1, 2, 4, 2, 1]);
        }

        public bool ValidMountainArray(int[] arr)
        {
            var n = arr.Length;
            if (n < 2 || arr[0] > arr[1]) 
                return false;

            var follow = false;
            for(var i = 0; i < n - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                    return false;

                if (!follow)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        follow = true;
                    }
                }
                else if(arr[i] < arr[i + 1])
                {
                    return false;
                }
            }
            return follow;
        }
    }
}
