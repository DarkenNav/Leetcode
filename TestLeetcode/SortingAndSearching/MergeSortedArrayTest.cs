using Leetcode.SortingAndSearching;

namespace TestLeetcode.SortingAndSearching
{
    public class MergeSortedArrayTest
    {
        [Test]
        public void Test1()
        {
            int[] nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            int m = 3;
            int[] nums2 = new int[] { 2, 5, 6 };
            int n = 3;

            new MergeSortedArrayCase().Merge(nums1, m, nums2, n);

            Assert.That(nums1, Is.EqualTo(new int[] { 1, 2, 2, 3, 5, 6 }));
        }

        [Test]
        public void Test2()
        {
            int[] nums1 = new int[] { 1 };
            int m = 1;
            int[] nums2 = new int[] {  };
            int n = 0;

            new MergeSortedArrayCase().Merge(nums1, m, nums2, n);

            Assert.That(nums1, Is.EqualTo(new int[] { 1 }));
        }

        [Test]
        public void Test3()
        {
            int[] nums1 = new int[] { 0 };
            int m = 0;
            int[] nums2 = new int[] { 1 };
            int n = 1;

            new MergeSortedArrayCase().Merge(nums1, m, nums2, n);

            Assert.That(nums1, Is.EqualTo(new int[] { 1 }));
        }
    }
}
