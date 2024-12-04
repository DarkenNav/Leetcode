using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings.Arrays
{
    /// <summary>
    /// 1346. Check If N and Its Double Exist
    /// </summary>
    public class CheckIfNAndItsDoubleExistCase
    {
        public void Cases()
        {
            // Output: true
            //var result_0 = CheckIfExist([10, 2, 5, 3]);
            // Output: false
            //var result_1 = CheckIfExist([3, 1, 7, 11]);
            // Output: true
            //var result_2 = CheckIfExist([7, 1, 14, 11]);

            // Output: true - arr[4] = 0, arr[7] = 4 && arr[1] = 8
            var result_3 = CheckIfExist([-20,8,-6,-14,0,-19,14,4]);
        }

        public bool CheckIfExist(int[] arr)
        {
            var set = new HashSet<int>();
            set.Add(arr[0]);
            for(var i = 1; i < arr.Length; i++)
            {
                if(set.Contains(2 * arr[i])
                    || (arr[i] % 2 == 0 && set.Contains(arr[i] / 2)))
                    return true;
                set.Add(arr[i]);
            }
            return false; 
        }

        public bool CheckIfExist_1(int[] arr)
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
