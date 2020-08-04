using System;
namespace Ozh.Utils.Sorting
{
    public abstract class Sorter<T>
    {
        protected readonly Comparison<T> comparision;

        public Sorter(Comparison<T> comparision)
        {
            this.comparision = comparision;
        }

        public abstract SortingType SortingType { get; }

        public abstract void Sort(T[] input);
    }
}
