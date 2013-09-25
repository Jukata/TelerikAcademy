using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    public class HashTable<K, T>
    {
        //Implement the data structure "hash table" in a class HashTable<K,T>.
        //Keep the data in array of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[])
        //with initial capacity of 16. When the hash table load runs over 75%,
        //perform resizing to 2 times larger capacity. Implement the following methods and properties:
        //Add(key, value), Find(key) -> value, Remove( key), Count, Clear(), this[], Keys.
        //Try to make the hash table to support iterating over its elements with foreach.

        private LinkedList<KeyValuePair<K, T>>[] hashArray;
        private int totalCount;
        private const double Overflow = 0.75;

        public HashTable(int size = 16)
        {
            this.hashArray = new LinkedList<KeyValuePair<K, T>>[size];

        }

        public ICollection<K> Keys
        {
            get
            {
                List<K> result = new List<K>();
                for (int i = 0; i < this.hashArray.Length; i++)
                {
                    if (this.hashArray[i] != null)
                    {
                        foreach (KeyValuePair<K, T> pair in hashArray[i])
                        {
                            result.Add(pair.Key);
                        }
                    }
                }

                return result;
            }
        }

        public int Count
        {
            get { return this.totalCount; }
        }

        public T this[K key]
        {
            get
            {
                if (key == null)
                {
                    throw new ArgumentNullException("Key can't be null.");
                }

                int index = GetHashedIndex(key);

                foreach (KeyValuePair<K, T> pair in this.hashArray[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        return pair.Value;
                    }
                }

                throw new InvalidOperationException("Key not found.");
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Key can't be null.");
                }

                Add(key, value);
            }
        }

        public T Find(K key)
        {
            T value = this[key];
            return value;
        }

        public void Add(K key, T value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key can't be null.");
            }

            int index = GetHashedIndex(key);
            KeyValuePair<K, T> newPair = new KeyValuePair<K, T>(key, value);

            LinkedList<KeyValuePair<K, T>> chain = GetChain(index);
            if (chain != null)
            {
                foreach (KeyValuePair<K, T> pair in chain)
                {
                    if (pair.Key.Equals(newPair.Key))
                    {
                        this.totalCount--;
                        chain.Remove(pair);
                        break;
                    }
                }
            }

            chain.AddLast(newPair);
            this.totalCount++;

            if (this.totalCount > this.hashArray.Length * Overflow)
            {
                this.Resize();
            }
        }

        public bool Remove(K key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key can't be null.");
            }

            var index = GetHashedIndex(key);
            var chain = GetChain(index);
            if (chain != null)
            {
                foreach (KeyValuePair<K, T> pair in chain)
                {
                    if (pair.Key.Equals(key))
                    {
                        chain.Remove(pair);
                        this.totalCount--;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Contains(K key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key can't be null.");
            }

            var index = GetHashedIndex(key);
            var chain = GetChain(index);
            if (chain != null)
            {
                foreach (KeyValuePair<K, T> pair in chain)
                {
                    if (pair.Key.Equals(key))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void Clear()
        {
            this.hashArray = new LinkedList<KeyValuePair<K, T>>[this.hashArray.Length];
            totalCount = 0;
        }

        private void Resize()
        {
            LinkedList<KeyValuePair<K, T>>[] oldList = this.hashArray;
            this.hashArray = new LinkedList<KeyValuePair<K, T>>[oldList.Length * 2];


            for (int i = 0; i < oldList.Length; i++)
            {
                if (oldList[i] != null)
                {
                    foreach (KeyValuePair<K, T> pair in oldList[i])
                    {
                        this.Add(pair.Key, pair.Value);
                    }
                }
            }
        }

        private LinkedList<KeyValuePair<K, T>> GetChain(int index)
        {
            if (this.hashArray[index] == null)
            {
                this.hashArray[index] = new LinkedList<KeyValuePair<K, T>>();
            }

            LinkedList<KeyValuePair<K, T>> chain = this.hashArray[index];
            return chain;
        }

        private int GetHashedIndex(K key)
        {
            int hashedIndex = key.GetHashCode() % this.hashArray.Length;
            return hashedIndex > 0 ? hashedIndex : hashedIndex * -1;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            for (int i = 0; i < this.hashArray.Length; i++)
            {
                if (this.hashArray[i] != null)
                {
                    foreach (KeyValuePair<K, T> pair in this.hashArray[i])
                    {
                        yield return pair;
                    }
                }
            }
        }
    }

}