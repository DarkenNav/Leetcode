using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch.Untro
{
    public class SqrtCase
    {
        public void Cases()
        {
            var x = 1000021132;
            if (x > int.MaxValue)
                ;
            
            var result = MySqrt(x);
            var expected = (int)Math.Sqrt(x);
        }        

        public int MySqrt(int x)
        {
            if (x == 0 || x == 1) 
                return x;

            var left = 0;
            var right = x;
            while(left <= right)
            {              
                int mid = left + (right - left) / 2;
                var pow = (long)mid * mid;
                if(pow > x)
                {
                    right = mid - 1;
                }
                else if (pow < x)
                {
                    left = mid + 1;
                }
                else 
                {
                    return mid;
                }
            }

            return right;
        }
    }
}
