using System;
namespace Ozh.Utils.Sorting
{
    public class SelectionSorter<T> : Sorter<T>
    {
        public SelectionSorter(Comparison<T> comparison) : base(comparison) { }

        public override SortingType SortingType => SortingType.Selection;

        public override void Sort(T[] input)
        {
            for(int i = 0; i < input.Length - 1; i++ )
            {
                var current = input[i];
                int minIndex = i;
                for(int j = i + 1; j < input.Length; j++)
                {
                    if(comparision(input[j], input[minIndex]) < 0 )
                    {
                        minIndex = j;
                    }
                }
                if(minIndex != i )
                {
                    input[i] = input[minIndex];
                    input[minIndex] = current;
                }
            }
        }


    }
}
