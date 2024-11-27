using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    public class CheckIfNAndItsDoubleExistCase
    {
        public void Cases()
        {
            // Output: true
            var result_0 = CheckIfExist([10, 2, 5, 3]);
            // Output: false
            var result_1 = CheckIfExist([3, 1, 7, 11]);
            // Output: true
            var result_2 = CheckIfExist([7, 1, 14, 11]);
        }

        public bool CheckIfExist(int[] arr)
        {
            for(var i = 0; i < arr.Length; i++)
            {
                for(var j = 0; j < arr.Length; j++ )
                {
                    if (i != j && arr[i] == 2 * arr[j])
                        return true;
                }
            }
            return false;
        }
    }
}
