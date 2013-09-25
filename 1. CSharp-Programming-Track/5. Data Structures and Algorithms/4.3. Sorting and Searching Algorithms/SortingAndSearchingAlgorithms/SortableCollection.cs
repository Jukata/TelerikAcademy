namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;
        private readonly Random randomGenarator = new Random();

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Searched item can't be null");
            }

            foreach (T element in items)
            {
                if (item.CompareTo(element) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Searched item can't be null");
            }

            int left = 0;
            int right = this.Items.Count - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int compareResult = item.CompareTo(this.Items[mid]);
                if (compareResult == 0)
                {
                    return true;
                }
                else if (compareResult < 0)
                {
                    right = mid - 1;
                }
                else // compareResult > 0
                {
                    left = mid + 1;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            // Fisher–Yates shuffle
            for (int i = 0; i < this.items.Count; i++)
            {
                int randomIndex = randomGenarator.Next(i, items.Count);
                T oldValue = this.items[i];
                this.items[i] = this.items[randomIndex];
                this.items[randomIndex] = oldValue;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
