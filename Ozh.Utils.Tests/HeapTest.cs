using System;
using Xunit;
using Ozh.Utils.Structures;

namespace Ozh.Utils.Tests
{
    public class HeapTest
    {
        [Fact]
        public void Should_Define_Parent_And_Child_Nodes()
        {
            Heap<int> heap = new Heap<int>(new[] { 16, 14, 10, 8, 7, 9, 3, 2, 4, 1 });
            var node14 = heap.Find((val) => val == 14);
            var node10 = heap.Find(val => val == 10);
            var root = heap.Find(val => val == 16);
            var node7 = heap.Find(val => val == 7);
            var node3 = heap.Find(val => val == 3);

            Assert.Equal(16, heap.Parent(node14).Data);
            Assert.Equal(16, heap.Parent(node10).Data);
            Assert.Null(heap.Parent(root));
            Assert.Equal(8, heap.LeftChild(node14).Data);
            Assert.Equal(7, heap.RightChild(node14).Data);
            Assert.Equal(1, heap.LeftChild(node7).Data);
            Assert.Null(heap.RightChild(node7));
            Assert.Null(heap.LeftChild(node3));
            Assert.Null(heap.RightChild(node3));
            Assert.Equal(node10.Data, heap.Parent(node3).Data);
        }

        [Fact]
        public void Should_MaxHeapify_Correctly()
        {
            int[] data = new int[] { 16, 4, 10, 14, 7, 9, 3, 2, 8, 1 };
            Heap<int> heap = new Heap<int>(data);
            heap.HeapifyAt(1, (a, b) => a > b);
            int[] expected = { 16, 14, 10, 8, 7, 9, 3, 2, 4, 1 };
            Assert.Equal(expected, heap.RawValues);
        }
    }
}
