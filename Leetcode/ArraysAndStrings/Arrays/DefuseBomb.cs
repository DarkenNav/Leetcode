using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode._Interfaces;

namespace Leetcode.ArraysAndStrings.Arrays
{
    // 1652. Defuse the Bomb
    public class DefuseBomb
        : IArrayLC, ISlidingWindowLC
    {
        public void Cases()
        {
            // Output: [12,10,16,13]
            var result_0 = Decrypt([5,7,1,4], 3);
            // Output: [0,0,0,0]
            var result_1 = Decrypt([1,2,3,4], 0);
            // Output: [12,5,6,13]
            var result_2 = Decrypt([2,4,9,3], -2);
        }

        public int[] Decrypt(int[] code, int k) 
        {
            var n = code.Length;
            var result = new int[n];    
            if(k == 0)
                return result;
                
            var start = 1;
            var end  = k; 
            var sum = 0;

            if(k < 0)
            {
               start = n - Math.Abs(k);
               end = n - 1; 
            }

            for(var j = start; j <= end; j++)
            {
                sum += code[j];
            }

            for(var i = 0; i < n; i++)
            {
                result[i] = sum;
                sum -= code[start % n];
                sum += code[(end+1)%n];
                start++;
                end++;
            }

            return result;
        }

        public int[] Decrypt_1(int[] code, int k) 
        {
            var n = code.Length;
            var result = new int[n];    
            if(k == 0)
                return result;
                
            var arr = new int[2*n];
            Array.Copy(code, 0, arr, 0, n);
            Array.Copy(code, 0, arr, n, n);

            var left = k > 0 ? 0 : n + k - 1;
            var window = Math.Abs(k);
            var sum = 0;
            for(var j = left + 1; j <= left + window; j++)
            {
                sum += arr[j];
            }
            result[0] = sum;

            for(var i = 1; i < n; i++)
            {
                var current = left + i;
                sum = sum - arr[current] + arr[current + window];
                result[i] = sum;
            }

            return result;
        }
    }
}
