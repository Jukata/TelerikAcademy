namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection is null.");
            }

            for (int i = 0; i < collection.Count; i++)
            {
                T valueToInsert = collection[i];
                int hole = i;

                while (hole > 0 && valueToInsert.CompareTo(collection[hole - 1]) < 0)
                {
                    collection[hole] = collection[hole - 1];
                    hole--;
                }

                collection[hole] = valueToInsert;
            }
        }
    }
}
