using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch.Intro
{
    public class FirstBadVersionCase
    {
        public void Cases()
        {
            bad = 4;
            var result = FirstBadVersion(5);
        }

        public int bad { get; set; }
        public bool IsBadVersion(int version)
        {
            return version >= bad;
        }

        public int FirstBadVersion(int n)
        {
            var left = 0;
            var right = n;
            while (left < right)
            {
                var version = left + (right - left) / 2;
                if (IsBadVersion(version))
                    right = version;
                else
                    left = version + 1;
            }
            return left;
        }
    }
}
