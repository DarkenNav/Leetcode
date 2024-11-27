using System.Text;

namespace Leetcode.ArraysAndStrings.Intro
{
    public class AddBinaryCase 
    {
        public void Case()
        {
            var result1 = AddBinary("11", "1");
            var result2 = AddBinary("1010", "1011");
            var result3 = AddBinary(
                "10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011",
                "110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011"
                );
            var result4 = AddBinary("100", "110010");
            var result5 = AddBinary("101111", "10");
        }
        public string AddBinary(string a, string b)
        {
            var aLength = a.Length;
            var bLength = b.Length;

            if (aLength >= bLength)
                return Sum(a, aLength, b, bLength);

            return Sum(b, bLength, a, aLength);
        }

        private string Sum(string more, int moreLength, string less, int lessLength)
        {
            var i = moreLength - 1;
            var j = lessLength - 1;
            var result = new StringBuilder("", moreLength);
            var accumulate = 0;
            while (i >= 0)
            {
                var lessValue = j < 0 ? '0' : less[j];

                if (more[i] == '1' && lessValue == '1')
                {
                    result.Insert(0, accumulate == 1 ? '1' : '0');
                    accumulate = 1;
                }
                else if (more[i] == '0' && lessValue == '0')
                {
                    result.Insert(0, accumulate == 1 ? '1' : '0');
                    accumulate = 0;
                }
                else
                {
                    result.Insert(0, accumulate == 1 ? '0' : '1');
                }

                i--;
                j--;
            }

            if(accumulate == 1)
                result.Insert(0, '1');

            return result.ToString();
        }
    }
}
