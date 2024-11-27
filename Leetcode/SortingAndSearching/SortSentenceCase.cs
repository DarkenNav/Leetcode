

namespace Leetcode.SortingAndSearching
{
    // Task 1859. Сортировка предложения
    public class SortSentenceCase 
    {
        public void Case()
        {
            var result1 = SortSentence("is2 sentence4 This1 a3");
            var result2 = SortSentence("Myself2 Me1 I4 and3");
        }

        public string SortSentence(string s)
        {
            var words = s.Split(' ');
            var result = words
                .OrderBy(x => x[x.Length - 1])
                .Select(y => y.Remove(y.Length - 1, 1));

            return string.Join(" ", result);
        }
    }
}
