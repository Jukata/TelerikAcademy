namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection is null.");
            }

            IList<T> sorted = QuickSort(collection);

            for (int i = 0; i < sorted.Count; i++)
            {
                if (i < collection.Count)
                {
                    collection[i] = sorted[i];
                }
                else
                {
                    collection.Add(sorted[i]);
                }
            }
        }

        private IList<T> QuickSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            T pivot = collection[collection.Count / 2];
            collection.RemoveAt(collection.Count / 2);
            IList<T> left = new List<T>();
            IList<T> right = new List<T>();

            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            List<T> result = new List<T>();
            result.AddRange(QuickSort(left));
            result.Add(pivot);
            result.AddRange(QuickSort(right));

            return result;
        }
    }
}
