using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch.Conclusion
{
    public class PowCase
    {
        public void Cases()
        {
            var result_0 = MyPow(2, -2147483648);
            var expected_0 = Math.Pow(2, -2147483648);

            //var result_1 = MyPow(2, -2);
            //var expected_1 = Math.Pow(2, -2);

            //var result_2 = MyPow(2, 2);
            //var expected_2 = Math.Pow(2, 2);

            //var result_4 = MyPow(2, 5);
            //var expected_4 = Math.Pow(2, 5);

            //var result_3 = MyPow(3, 3);
            //var expected_3 = Math.Pow(3, 3);

            //var result_5 = MyPow(3, 4);
            //var expected_5 = Math.Pow(3, 4);
        }

        // O(n)
        public double MyPow_ON(double x, int n)
        {
            if(x == 0) 
                return 0;

            var negative = n < 0;
            var count = negative ? n * -1 : n;
            var result = x;
            for (var i = 1; i < count; i++) 
            {
                result *= x;
            }
            if(negative)
                result = 1 / result;

            return result;
        }

        // O(log n) - reqursion
        public double MyPow_StartR(double x, int n)
        {
            if (x == 1 || n == 0 || (n == int.MinValue && x == -1))
                return 1;
            if (x == 0 || n == int.MinValue)
                return 0;
            
            var result = MyPow_R(x, Math.Abs(n));
            return n < 0 ? 1 / result : result;
        }

        private Dictionary<int, double> memo = new Dictionary<int, double>();
        public double MyPow_R(double x, int n)
        {
            if(n == 0)
                return 1;

            if(!memo.ContainsKey(n / 2))
                memo[n / 2] = MyPow(x, n / 2);

            if (n % 2 == 0)
                return memo[n / 2] * memo[n / 2];
            return x * memo[n / 2] * memo[n / 2];
        }


        // O(log n) - binary
        public double MyPow(double x, int n)
        {
            if (x == 1 || n == 0 || (n == int.MinValue && x == -1))
                return 1;
            if (x == 0 || n == int.MinValue)
                return 0;

            var negative = n < 0;
            var count = negative ? Math.Abs(n) : n;
            var set = new HashSet<int>();
            while (count > 0)
            {
                set.Add(count);
                count /= 2;
            }
            set.Add(0);

            var result = 1.0;
            foreach (var i in set.Order())
            {
                if (i % 2 == 0)
                    result *= result;
                else
                    result = x * result * result;
            }

            if (negative)
                result = 1 / result;

            return result;
        }
    }
}
