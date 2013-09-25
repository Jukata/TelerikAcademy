namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection is null.");
            }

            for (int i = 0; i < collection.Count; i++)
            {
                int minElementIndex = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[minElementIndex]) < 0)
                    {
                        minElementIndex = j;
                    }
                }
                if (minElementIndex != i)
                {
                    T oldValue = collection[i];
                    collection[i] = collection[minElementIndex];
                    collection[minElementIndex] = oldValue;
                }
            }
        }
    }
}
