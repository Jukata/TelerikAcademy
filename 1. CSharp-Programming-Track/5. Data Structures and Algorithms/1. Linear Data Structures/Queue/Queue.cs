using System;
using System.Collections;
using System.Collections.Generic;

public class Queue<T> : IEnumerable<T>
{
    private LinkedList<T> elements;

    public int Count
    {
        get { return this.elements.Count; }
    }

    public Queue()
    {
        this.elements = new LinkedList<T>();
    }

    public void Enqueue(T element)
    {
        this.elements.AddLast(element);
    }

    public T Dequeue()
    {
        if (this.elements.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        T element = this.elements.First.Value;
        this.elements.RemoveFirst();
        return element;
    }

    public T Peek()
    {
        if (this.elements.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        T element = this.elements.First.Value;
        return element;
    }

    public void Clear()
    {
        this.elements.Clear();
    }

    public bool Contains(T element)
    {
        bool contains = this.elements.Contains(element);
        return contains;
    }

    public T[] ToArray()
    {
        T[] newArray = new T[this.elements.Count];

        int index = 0;
        foreach (T element in this.elements)
        {
            newArray[index] = element;
            index++;
        }

        return newArray;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.elements.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public override string ToString()
    {
        return string.Join(", ", this.elements);
    }
}
