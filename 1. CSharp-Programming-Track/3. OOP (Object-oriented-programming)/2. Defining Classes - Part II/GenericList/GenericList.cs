using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    //Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
    //Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
    //Implement methods for adding element, accessing element by index, removing element by index,
    //inserting element at given position, clearing the list, finding element by its value and ToString(). 
    //Check all input parameters to avoid accessing elements at invalid positions.
    //Implement auto-grow functionality: when the internal array is full, 
    //create a new array of double size and move all elements to it.


    public class GenericList<T>
        where T : IComparable
    {
        private const int DefaultListSize = 4;
        private T[] elements;
        private int capacity;
        private int count = 0;

        public T[] Elements
        {
            get
            {
                return this.elements;
            }
            private set
            {
                this.elements = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value <= count)
                {
                    throw new ArgumentException("Capacity must be bigger than actual size");
                }
                else
                {
                    if (this.count == 0)
                    {
                        this.capacity = value;
                        this.elements = new T[this.capacity];
                    }
                    else
                    {
                        this.capacity = value;
                        T[] newElements = new T[this.capacity]; // make array with the new capacity
                        for (int i = 0; i < this.capacity; i++) // copy elements 
                        {
                            newElements[i] = this.elements[i];
                        }
                        this.Elements = newElements;
                    }
                }
            }
        }
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public GenericList(int capacity = DefaultListSize)
        {
            this.Capacity = capacity;
            elements = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("Index out of range.");
                }
                return this.elements[index];
            }
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("Index out of range.");
                }
                this.elements[index] = value;
            }
        }

        public void Add(T element)
        {
            if (this.Count >= capacity)
            {
                EnsureCapacity();
            }
            elements[this.Count] = element;
            this.count++;

        }

        private void EnsureCapacity()
        {
            long newCapacity = this.capacity * 2;
            if (newCapacity > int.MaxValue)
            {
                newCapacity = int.MaxValue;
            }
            this.capacity = (int)newCapacity;
            T[] newElements = new T[this.Capacity];
            for (int i = 0; i < this.Count; i++)
            {
                newElements[i] = this.elements[i];
            }
            this.Elements = newElements;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Index out of range.");
            }

            T[] newElements = new T[this.Capacity];
            for (int i = 0, j = 0; i < this.Count; i++)
            {
                if (i == index)
                {
                    continue;
                }
                newElements[j] = this.elements[i];
                j++;
            }
            this.Elements = newElements;
            this.count--;
        }

        public void InsertAt(int index, T element)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException("Index out of range.");
            }
            count++;
            if (this.Count == this.Capacity)
            {
                EnsureCapacity();
            }
            T[] newElements = new T[this.Capacity];
            for (int i = 0, j = 0; i < this.Count; i++, j++)
            {
                if (j == index)
                {
                    newElements[j] = element;
                    i--;
                }
                else
                {
                    newElements[j] = this.elements[i];
                }
            }
            this.elements = newElements;
        }
        public void Clear()
        {
            this.elements = new T[DefaultListSize];
            this.count = 0;
            this.capacity = DefaultListSize;
        }

        public int FindIndex(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Argument cannot be null.");
            }
            for (int i = 0; i < this.Count; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    return i;
                }
            }
            return -1; // not found
        }

        //Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element
        //in the  GenericList<T>. You may need to add a generic constraints for the type T.
        public T Min(T first, T second)
        {
            if (first.CompareTo(second) <= 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        public T Max(T first, T second)
        {
            if (first.CompareTo(second) >= 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }
    }
}
