namespace Leetcode.ArraysAndStrings.Intro
{
    public class TwoSumIICase 
    {
        public void Cases()
        {
            // Output: [1,2]
            var result_1 = TwoSum([2, 7, 11, 15], 9);
            // Output: [1,3]
            var result_2 = TwoSum([2, 3, 4], 6);
            // Output: [1,2]
            var result_3 = TwoSum([-1, 0], -1);
        }

        // reqursion O(n) --------------------------------------------
        public int[] TwoSum(int[] numbers, int target, int left = 0, int right = int.MaxValue)
        {
            if(right == int.MaxValue)
                right = numbers.Length - 1;

            var res = numbers[left] + numbers[right];
            if (res == target)
                return [left + 1, right + 1];
            else if (res > target)
                right--;
            else
                left++;

            return TwoSum(numbers, target, left, right);
        }

        // O(n) -------------------------------------------------
        public int[] TwoSum_1(int[] numbers, int target)
        {
            var i = 0;
            var j = numbers.Length - 1;
            while (i < j)
            {
                if (numbers[i] + numbers[j] == target)
                {
                    break;
                }
                else if(numbers[i] + numbers[j] > target)
                {
                    j--;
                }
                else
                { 
                    i++; 
                }

            }
            return new int[] { i + 1, j + 1 };
        }

        // O(n^2) ---------------------------------------------------
        public int[] TwoSum_2(int[] numbers, int target)
        {
            var result = new int[2] { 1, 1 };
            var numbersLength = numbers.Length;
            for (var i = 0; i < numbersLength - 1; i++)
            {
                for (var j = i + 1; j < numbersLength; j++)
                {
                    if (numbers[i] + numbers[j] == target)
                    {
                        result[0] += i;
                        result[1] += j;
                        return result;
                    }
                }
            }
            return result;
        }
    }
}
