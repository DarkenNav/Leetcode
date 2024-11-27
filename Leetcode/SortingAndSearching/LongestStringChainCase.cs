namespace Leetcode.SortingAndSearching
{
    // Task 1048. Longest String Chain
    // Не решено
    public class LongestStringChainCase
    {
        public void Case()
        {
            var result1 = LongestStrChain(new string[] { "a", "b", "ba", "bca", "bda", "bdca" });
            var result2 = LongestStrChain(new string[] { "xbc", "pcxbcf", "xb", "cxbc", "pcxbc" });
            var result3 = LongestStrChain(new string[] { "abcd", "dbqca" });

        }

        public int LongestStrChain(string[] words)
        {
            var sortWords = words.OrderDescending().ToArray();
            for (int i = 0; i < words.Length; i++)
            {
                for (var j = 0; j < sortWords[i].Length; j++)
                { 
                
                }
            }

            return 0;
        }
    }
}
