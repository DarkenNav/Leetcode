using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch.Conclusion
{
    public class ValidPerfectSquareCase
    {
        public void Cases()
        {
            var result = IsPerfectSquare(14);
        }

        // Поиск квадратного корня методом ньютона
        // очень похоже на бинарный поиск
        public bool IsPerfectSquare(int num)
        {
            double x = 1;
            double accuracy = 1e-15;
            while (true)
            {
                double nx = (x + num / x) / 2;
                if (Math.Abs(x - nx) < accuracy)
                    break;
                x = nx;
            }
            if (x % 1 == 0)
                return true;
            return false;
        }
    }
}
