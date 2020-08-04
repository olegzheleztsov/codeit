using System;
using Xunit;
using Ozh.Utils.Sorting;

namespace Ozh.Utils.Tests
{
    public class MergeSorterTest
    {
        [Fact]
        public void Merge_Sorter_Should_Sort_Correctly()
        {
            var sorter = new MergeSorter<int>((a, b) => a.CompareTo(b));
            var input = new int[] { 5, 2, 4, 6, 1, 3 };
            var emptyInput = new int[] { };
            sorter.Sort(input);
            sorter.Sort(emptyInput);
            Assert.Equal(new int[] { 1, 2, 3, 4, 5, 6 }, input);
            Assert.Equal(new int[] { }, emptyInput);
        }

        [Fact]
        public void Merge_Sort_Should_Correctly_Sort_In_Decreasing_Order()
        {
            var sorter = new MergeSorter<int>((a, b) => b.CompareTo(a));
            var input = new int[] { 5, 2, 4, 6, 1, 3 };
            var emptyInput = new int[] { };
            sorter.Sort(input);
            sorter.Sort(emptyInput);
            Assert.Equal(new int[] { 6, 5, 4, 3, 2, 1 }, input);
            Assert.Equal(new int[] { }, emptyInput);
        }
    }
}
