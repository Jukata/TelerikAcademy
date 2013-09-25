using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    public class HashedSet<T> : IEnumerable<T>
    {
        private HashTable<T, T> innerTable;

        public HashedSet(int size = 16)
        {
            innerTable = new HashTable<T, T>(size);
        }

        public int Count
        {
            get
            {
                return this.innerTable.Count;
            }
        }

        public T this[T index]
        {
            get { return this.innerTable[index]; }
        }

        public void Add(T value)
        {
            this.innerTable.Add(value, value);
        }

        public T Find(T value)
        {
            T result = this.innerTable.Find(value);
            return result;
        }

        public void Remove(T value)
        {
            this.innerTable.Remove(value);
        }

        public void Clear()
        {
            this.innerTable.Clear();
        }

        public bool Contains(T value)
        {
            if (this.innerTable.Contains(value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public HashedSet<T> UnionWith(HashedSet<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Other collection can't be null");
            }

            HashedSet<T> union = new HashedSet<T>(this.Count);

            foreach (T item in this)
            {
                union.Add(item);
            }

            foreach (T item in other)
            {
                union.Add(item);
            }

            return union;
        }

        public HashedSet<T> IntersectWith(HashedSet<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Other collection can't be null");
            }

            HashedSet<T> intersection = new HashedSet<T>(this.Count);

            foreach (T item in other)
            {
                if (this.Contains(item))
                {
                    intersection.Add(item);
                }
            }

            return intersection;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (KeyValuePair<T, T> item in this.innerTable)
            {
                yield return item.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

