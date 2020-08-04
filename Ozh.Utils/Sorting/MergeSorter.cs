using System;
namespace Ozh.Utils.Sorting
{
    public class MergeSorter<T> : Sorter<T>
    {

        public MergeSorter(Comparison<T> comparison) : base(comparison) { }

        public override SortingType SortingType => SortingType.Merge;

        public override void Sort(T[] input)
        {
            MergeSort(input, 0, input.Length - 1);
        }

        private void MergeSort(T[] array, int leftIndex, int rightIndex)
        {
            if(leftIndex < rightIndex)
            {
                int midIndex = (int)Math.Floor((double)(leftIndex + rightIndex) / 2);
                MergeSort(array, leftIndex, midIndex);
                MergeSort(array, midIndex + 1, rightIndex);
                Merge(array, leftIndex, midIndex, rightIndex);
            }
        }

        private void Merge(T[] array, int leftIndex, int midIndex, int rightIndex) {
            int leftLength = midIndex - leftIndex + 1;
            int rightLenth = rightIndex - midIndex;

            var leftSubArray = new T[leftLength];
            var rightSubArray = new T[rightLenth];

            for(int i = 0; i < leftSubArray.Length; i++)
            {
                leftSubArray[i] = array[leftIndex + i];
            }
            for(int i = 0; i < rightSubArray.Length; i++)
            {
                rightSubArray[i] = array[midIndex + i + 1];
            }

            int li = 0, rj = 0;
            for(int k = leftIndex; k <= rightIndex; k++ )
            {
                if( (li < leftSubArray.Length && rj < rightSubArray.Length && comparision(leftSubArray[li], rightSubArray[rj]) < 0) ||
                    (li < leftSubArray.Length && rj >= rightSubArray.Length))
                {
                    array[k] = leftSubArray[li];
                    li++;
                } else if(rj < rightSubArray.Length)
                {
                    array[k] = rightSubArray[rj];
                    rj++;
                }
            }
        }
    }
}
