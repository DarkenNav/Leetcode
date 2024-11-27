using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    public class DuplicateZerosCase
    {
        public void Cases()
        {
            // Output: [1,0,0,2,3,0,0,4]
            int[] input_1 = { 1, 0, 2, 3, 0, 4, 5, 0 };
            DuplicateZeros(input_1);
            // Output: [1,2,0,0]
            int[] input_2 = { 1, 2, 0, 3 };
            DuplicateZeros(input_2);
        }

        // ----- O(n)
        public void DuplicateZeros(int[] arr)
        {
            var zCount = arr.Count(x => x == 0);
            var tmp = new int[arr.Length + zCount];

            var j = tmp.Length - 1;
            for(var i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] != 0)
                    tmp[j] = arr[i];
                else
                    j--;
                j--;
            }

            for(var i = 0; i < arr.Length; i++)
            {
                arr[i] = tmp[i];
            }
        }

        // ----- O(n^2)
        public void DuplicateZeros_1(int[] arr)
        {
            var n = arr.Length;
            for(var i = 0; i < n - 1; i++ )
            {
                if (arr[i] != 0) continue;
                for(var j = n - 1; j > i + 1; j-- )
                {
                    arr[j] = arr[j - 1];
                }
                arr[i + 1] = 0;
                i++;
            }
        }
    }
}
