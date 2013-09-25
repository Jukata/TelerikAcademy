namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection is null.");
            }

            IList<T> sorted = MergeSort(collection);

            for (int i = 0; i < sorted.Count; i++)
            {
                collection[i] = sorted[i];
            }
        }

        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            int mid = collection.Count / 2;

            IList<T> left = new List<T>();
            IList<T> right = new List<T>();

            for (int i = 0; i < collection.Count; i++)
            {
                if (i < mid)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private IList<T> Merge(IList<T> leftCollection, IList<T> rightCollection)
        {
            int leftIndex = 0;
            int rightIndex = 0;

            IList<T> result = new List<T>();

            while (leftIndex < leftCollection.Count || rightIndex < rightCollection.Count)
            {
                if (leftIndex < leftCollection.Count && rightIndex < rightCollection.Count)
                {
                    if (leftCollection[leftIndex].CompareTo(rightCollection[rightIndex]) < 0)
                    {
                        result.Add(leftCollection[leftIndex]);
                        leftIndex++;
                    }
                    else
                    {
                        result.Add(rightCollection[rightIndex]);
                        rightIndex++;
                    }
                }
                else if (leftIndex < leftCollection.Count)
                {
                    result.Add(leftCollection[leftIndex]);
                    leftIndex++;
                }
                else // rightIndex < rightCollection.count
                {
                    result.Add(rightCollection[rightIndex]);
                    rightIndex++;
                }
            }

            return result;
        }
    }
}
