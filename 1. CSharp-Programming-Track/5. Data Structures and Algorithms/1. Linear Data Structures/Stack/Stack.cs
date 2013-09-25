using System;
using System.Collections;
using System.Collections.Generic;

public class Stack<T> : IEnumerable<T>
{
    private int top;
    private T[] elements;

    public int Capacity
    {
        get { return this.elements.Length; }
    }

    public int Count
    {
        get { return this.top + 1; }
    }

    public Stack(int capacity = 4)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException("Stack capacity must be positive integer.");
        }

        this.elements = new T[capacity];
        this.top = -1;
    }

    public void Push(T element)
    {
        this.top++;
        if (this.top >= this.elements.Length)
        {
            EnsureCapacity();
        }

        this.elements[top] = element;
    }

    private void EnsureCapacity()
    {
        int newSize;
        if (this.elements.Length == 0)
        {
            newSize = 1;
        }
        else
        {
            newSize = this.elements.Length * 2;
        }

        T[] newArray = new T[newSize];

        for (int i = 0; i < this.elements.Length; i++)
        {
            newArray[i] = this.elements[i];
        }

        this.elements = newArray;
    }

    public T Pop()
    {
        if (this.top == -1)
        {
            throw new InvalidOperationException("The stack is empty.");
        }

        T element = this.elements[this.top];
        this.elements[this.top] = default(T);
        this.top--;

        return element;
    }

    public T Peek()
    {
        if (this.top == -1)
        {
            throw new InvalidOperationException("The stack is empty");
        }

        T element = this.elements[this.top];
        return element;
    }

    public void Clear()
    {
        this.elements = new T[4];
        this.top = -1;
    }

    public void TrimExcess()
    {
        if (this.Capacity == this.top)
        {
            return;
        }

        T[] newArray = new T[this.top];

        for (int i = 0; i < newArray.Length; i++)
        {
            newArray[i] = this.elements[i];
        }

        this.elements = newArray;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < this.top; i++)
        {
            if (element.Equals(this.elements[i]))
            {
                return true;
            }
        }

        return false;
    }

    public T[] ToArray()
    {
        T[] resultArray = new T[this.top];

        for (int i = 0; i < resultArray.Length; i++)
        {
            resultArray[i] = this.elements[i];
        }

        return resultArray;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.top; i >= 0; i--)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public override string ToString()
    {
        return string.Join(" ", this.elements);
    }
}