using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Ozh.Utils.Structures
{
    public class Heap<T>
    {

        private readonly List<HeapNode<T>> nodes;

        public Heap(T[] data)
        {
            nodes = new List<HeapNode<T>>(data.Length);
            foreach(var element in data)
            {
                nodes.Add(new HeapNode<T>(element));
            }
        }

        public int IndexOf(HeapNode<T> node)
        {
            return nodes.IndexOf(node);
        }

        public HeapNode<T> Parent(HeapNode<T> node)
        {
            int sourceIndex = IndexOf(node);
            if (sourceIndex <= 0)
            {
                return null;
            }
            int parentIndex = (int)Math.Floor((double)(sourceIndex - 1) / 2);
            return nodes[parentIndex];
        }

        public HeapNode<T> LeftChild(HeapNode<T> node)
        {
            int sourceIndex = IndexOf(node);
            if (sourceIndex < 0)
            {
                throw new ArgumentException(nameof(node));
            }
            int leftChildIndex = LeftChildIndex(sourceIndex);
            if (leftChildIndex < nodes.Count)
            {
                return nodes[leftChildIndex];
            }
            return null;
        }

        public int LeftChildIndex(int parentIndex) => 2 * parentIndex + 1;

        public int RightChildIndex(int parentIndex) => 2 * parentIndex + 2;

        public HeapNode<T> RightChild(HeapNode<T> node)
        {
            int sourceIndex = IndexOf(node);
            if (sourceIndex < 0)
            {
                throw new ArgumentException(nameof(node));
            }
            int rightChildIndex = RightChildIndex(sourceIndex);
            if (rightChildIndex < nodes.Count)
            {
                return nodes[rightChildIndex];
            }
            return null;
        }

        public HeapNode<T> Find(Predicate<T> predicate)
        {
            foreach(var node in nodes)
            {
                if(predicate(node.Data))
                {
                    return node;
                }
            }
            return default;
        }

        public void HeapifyAt(int index, System.Func<T, T, bool> isLeftBigger)
        {
            if(index >= 0 && index < nodes.Count)
            {
                int leftChildIndex = LeftChildIndex(index);
                int rightChildIndex = RightChildIndex(index);
                int largestIndex = -1;
                if(leftChildIndex >= 0 && leftChildIndex < nodes.Count && isLeftBigger(nodes[leftChildIndex].Data, nodes[index].Data))
                {
                    largestIndex = leftChildIndex;
                } else
                {
                    largestIndex = index;
                }
                if(rightChildIndex >= 0 && rightChildIndex < nodes.Count && isLeftBigger(nodes[rightChildIndex].Data, nodes[largestIndex].Data))
                {
                    largestIndex = rightChildIndex;
                }
                if(largestIndex != index )
                {
                    var temp = nodes[index];
                    nodes[index] = nodes[largestIndex];
                    nodes[largestIndex] = temp;
                    HeapifyAt(largestIndex, isLeftBigger);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[ ");
            for (int i = 0; i < nodes.Count; i++)
            {
                stringBuilder.Append(i == nodes.Count - 1 ? nodes[i].ToString() : nodes[i].ToString() + ", ");
            }
            stringBuilder.Append(" ]");
            return stringBuilder.ToString();
        }

        public T[] RawValues => nodes.Select(node => node.Data).ToArray();
    }

    public class HeapNode<T>
    {
        public T Data { get; }

        public HeapNode(T data) => Data = data;

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
