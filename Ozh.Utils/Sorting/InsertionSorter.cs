using System;
namespace Ozh.Utils.Sorting
{
    public class InsertionSorter<T> : Sorter<T>
    {
        public InsertionSorter(Comparison<T> comparison) : base(comparison) 
        {
        }

        public override SortingType SortingType => SortingType.Insertion;

        public override void Sort(T[] input)
        {
            for(int j = 1; j < input.Length; j++ )
            {
                var key = input[j];
                int i = j - 1;
                while ( i >= 0 && comparision(input[i], key) > 0)
                {
                    input[i + 1] = input[i];
                    i--;
                }
                input[i + 1] = key;
            }
        }
    }
}
