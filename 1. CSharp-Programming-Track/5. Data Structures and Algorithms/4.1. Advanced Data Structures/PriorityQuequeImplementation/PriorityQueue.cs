using System;
using System.Collections.Generic;

//Implement a class PriorityQueue<T> based on the data structure "binary heap".

public class PriorityQueue<T> where T : IComparable<T>
{
    private List<T> elements;

    public PriorityQueue(int capacity = 16)
    {
        elements = new List<T>(capacity);
    }

    public int Count
    {
        get { return this.elements.Count; }
    }

    public void Enqueue(T value)
    {
        this.elements.Add(value);

        for (int i = this.Count - 1; this.HasParent(i); i = this.ParentIndex(i))
        {
            int parentIndex = this.ParentIndex(i);

            if (this.elements[parentIndex].CompareTo(this.elements[i]) > 0)
            {
                T prev = this.elements[i];
                this.elements[i] = this.elements[parentIndex];
                this.elements[parentIndex] = prev;
            }
            else
            {
                break;
            }
        }
    }

    public T Dequeue()
    {
        if (this.elements.Count == 0)
        {
            throw new InvalidOperationException("Can't dequeue from empty queque.");
        }

        T result = this.Peek();

        this.elements[0] = this.elements[this.Count - 1];
        this.elements.RemoveAt(this.Count - 1);

        for (int i = 0, smallerChild; this.HasLeftChild(i); i = smallerChild)
        {
            smallerChild = this.LeftIndex(i);

            if (this.HasRightChild(i) && this.elements[this.LeftIndex(i)].CompareTo(this.elements[this.RightIndex(i)]) > 0)
            {
                smallerChild = this.RightIndex(i);
            }
            if (this.elements[i].CompareTo(this.elements[smallerChild]) > 0)
            {
                T prev = this.elements[i];
                this.elements[i] = this.elements[smallerChild];
                this.elements[smallerChild] = prev;
            }
            else
            {
                break;
            }
        }

        return result;
    }

    private bool HasParent(int i)
    {
        return (i > 0);
    }

    private int ParentIndex(int i)
    {
        int index = (i - 1) / 2;
        return index;
    }

    private int LeftIndex(int i)
    {
        int index = (i * 2) + 1;
        return index;
    }

    private int RightIndex(int i)
    {
        int index = (i * 2) + 2;
        return index;
    }

    private bool HasLeftChild(int i)
    {
        return (this.LeftIndex(i) < this.Count);
    }

    private bool HasRightChild(int i)
    {
        return (this.RightIndex(i) < this.Count);
    }

    public T Peek()
    {
        return this.elements[0];
    }

    public void Clear()
    {
        this.elements.Clear();
    }
}

