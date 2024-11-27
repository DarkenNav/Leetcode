using Leetcode.SortingAndSearching;

namespace TestLeetcode.SortingAndSearching
{
    public class SortSentenceTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            var task = new SortSentenceCase();
            var expected = task.SortSentence("is2 sentence4 This1 a3");

            Assert.That(expected, Is.EqualTo("This is a sentence"));
        }

        [Test]
        public void Test2()
        {
            var task = new SortSentenceCase();
            var expected = task.SortSentence("Myself2 Me1 I4 and3");

            Assert.That(expected, Is.EqualTo("Me Myself and I"));
        }

    }
}
