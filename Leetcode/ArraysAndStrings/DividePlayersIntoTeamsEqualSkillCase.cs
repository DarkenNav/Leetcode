using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArraysAndStrings
{
    public class DividePlayersIntoTeamsEqualSkillCase
    {
        public void Cases()
        {
            // Output: 22
            var result_0 = DividePlayers([3, 2, 5, 1, 3, 4]);
            // Output: 12
            var result_1 = DividePlayers([3, 4]);
            // Output: -1
            var result_2 = DividePlayers([1, 1, 2, 3]);
        }

        public long DividePlayers(int[] skill)
        {
            Array.Sort(skill);
            var left = 0;
            var right = skill.Length - 1;
            long chemistry = 0;
            var totalSkill = skill[left] + skill[right];
            while (left < right)
            {
                chemistry += skill[left] * skill[right];
                if (totalSkill != (skill[left] + skill[right]))
                    return -1;
                left++;
                right--;
            }

            return chemistry;
        }
    }
}
