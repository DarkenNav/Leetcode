using Leetcode.BinarySearch.Untro;

namespace TestLeetcode.BinarySearch
{
    public class BinarySearchTest
    {
        [Test]
        public void Test1()
        {
            var nums_0 = new int[] { -1, 0, 3, 5, 9, 12 };
            var target_0 = 9;
            var result = new BinarySearchCase().Search(nums_0, target_0);

            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void Test2()
        {
            var nums_0 = new int[] { -1, 0, 3, 5, 9, 12 };
            var target_0 = 2;
            var result = new BinarySearchCase().Search(nums_0, target_0);

            Assert.That(result, Is.EqualTo(-1));
        }


        [Test]
        public void Test3()
        {
            var nums_0 = new int[] { 5 };
            var target_0 = 5;
            var result = new BinarySearchCase().Search(nums_0, target_0);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Test4()
        {
            var nums_0 = new int[] { -1,0,5 };
            var target_0 = 0;
            var result = new BinarySearchCase().Search(nums_0, target_0);

            Assert.That(result, Is.EqualTo(1));
        }
    }
}
