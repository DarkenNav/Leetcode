
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.SortingAndSearching
{
    // Task 3186. Maximum Total Damage With Spell Casting
    // Не решено
    public class MaximumTotalDamageCase 
    {
        public void Case()
        {
            MaximumTotalDamage(new int[] { 1, 1, 3, 4 });
            MaximumTotalDamage(new int[] { 7, 1, 6, 6 });

        }

        public long MaximumTotalDamage(int[] power)
        {
            var resultPower = power[0];
            for (var i = 1; i < power.Length; i++)
            {
                if (power[i] == resultPower
                    || Math.Abs(power[i] - resultPower) > 2)
                {
                    resultPower += power[i];
                }
            }

            return resultPower;
        }
    }
}
