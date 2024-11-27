
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.SortingAndSearching
{
    // 1927. Sum Game
    // Не понимаю цели задачи, и решение замороченное какое то получается
    public class SumGameCase 
    {
        public void Case()
        {
            var result1 = SumGame("5023");
            var result2 = SumGame("25??");
            var result3 = SumGame("?3295???");
        }

        public bool SumGame(string num)
        {
            var aliceSum = 0; 
            var bobSum = 0;
            var stepAlice = true;

            var list = new List<int>();

            var length = num.Length;
            var half = length / 2;
            for (var i = 0; i < half; i++)
            {
                var _num = num[i] == '?' ? -1 : int.Parse(num[i].ToString());
                if (num[i] > 0)
                {
                    aliceSum += _num;
                }
                list.Add(_num);
            }
            for (var i = half; i < length; i++)
            {
                var _num = num[i] == '?' ? -1 : int.Parse(num[i].ToString());
                if (num[i] > 0)
                {
                    bobSum += _num;
                }
                list.Add(_num);
            }

            for (var i = 0; i < length; i++)
            {
                if (list[i] == -1)
                {
                    if (stepAlice)
                    {
                        if (aliceSum != bobSum)
                        {
                            var dif = aliceSum - bobSum;
                            if (dif < 0)
                                aliceSum += dif;

                            list[i] = dif;
                        }
                        else
                            list[i] = 0;
                        stepAlice = false;
                    }
                    else
                    {
                        stepAlice = true;
                    }
                }
            }


            return false;
        }
    }
}
