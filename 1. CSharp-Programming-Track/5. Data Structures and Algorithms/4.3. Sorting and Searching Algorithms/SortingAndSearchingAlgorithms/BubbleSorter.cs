namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BubbleSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection is null.");
            }

            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int i = 1; i < collection.Count; i++)
                {
                    if (collection[i].CompareTo(collection[i - 1]) < 0)
                    {
                        T oldValue = collection[i - 1];
                        collection[i - 1] = collection[i];
                        collection[i] = oldValue;
                        swapped = true;
                    }
                }
            }
        }
    }
}
