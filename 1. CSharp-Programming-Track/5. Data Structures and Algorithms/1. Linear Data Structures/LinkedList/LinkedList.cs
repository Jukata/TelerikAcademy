using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class LinkedList<T> : IEnumerable<T>
    where T : IComparable<T>
{
    public ListItem<T> First { get; private set; }
    public ListItem<T> Last { get; private set; }
    public int Count { get; private set; }

    public ListItem<T> AddFirst(T value)
    {
        ListItem<T> item = new ListItem<T>(value);
        this.AddFirst(item);
        return item;
    }

    public void AddFirst(ListItem<T> item)
    {
        if (item == null)
        {
            throw new ArgumentNullException("Item node can't be null.");
        }

        if (this.First == null)
        {
            this.First = item;
            this.Last = item;
        }
        else
        {
            item.Next = this.First;
            this.First.Previous = item;
            this.First = item;
        }

        this.Count++;
    }

    public ListItem<T> AddLast(T value)
    {
        ListItem<T> item = new ListItem<T>(value);
        this.AddLast(item);
        return item;
    }

    public void AddLast(ListItem<T> item)
    {
        if (this.Last == null)
        {
            this.First = item;
            this.Last = item;
        }
        else
        {
            item.Previous = this.Last;
            this.Last.Next = item;
            this.Last = item;
        }

        this.Count++;
    }

    public void RemoveFirst()
    {
        if (this.First == null)
        {
            return;
        }

        if (this.First.Next == null)
        {
            this.Clear();
            return;
        }

        ListItem<T> first = this.First;
        this.First = this.First.Next;
        this.First.Previous = null;
        first.Next = null;

        this.Count--;

    }

    public void RemoveLast()
    {
        if (this.Last == null)
        {
            return;
        }

        if (this.Last.Previous == null)
        {
            this.Clear();
            return;
        }

        ListItem<T> Last = this.Last;
        this.Last = this.Last.Previous;
        this.Last.Next = null;
        Last.Previous = null;

        this.Count--;
    }

    public void Clear()
    {
        this.First = null;
        this.Last = null;
        this.Count = 0;
    }

    public ListItem<T> AddAfter(ListItem<T> afterItem, T value)
    {
        ListItem<T> item = new ListItem<T>(value);
        AddAfter(afterItem, item);
        return item;
    }

    public void AddAfter(ListItem<T> afterItem, ListItem<T> item)
    {
        if (!this.Contains(afterItem))
        {
            throw new InvalidOperationException("Node item isn't in the list.");
        }

        if (afterItem.Next == null)
        {
            this.AddLast(item);
            return;
        }

        afterItem.Next.Previous = item;
        item.Next = afterItem.Next;
        item.Previous = afterItem;
        afterItem.Next = item;
        this.Count++;
    }

    public ListItem<T> AddBefore(ListItem<T> beforeItem, T value)
    {
        ListItem<T> item = new ListItem<T>(value);
        AddBefore(beforeItem, item);
        return item;
    }

    public void AddBefore(ListItem<T> beforeItem, ListItem<T> item)
    {
        if (!this.Contains(beforeItem))
        {
            throw new InvalidOperationException("Node item isn't in the list.");
        }

        if (beforeItem.Previous == null)
        {
            this.AddFirst(item);
            return;
        }

        beforeItem.Previous.Next = item;
        item.Previous = beforeItem.Previous;
        item.Next = beforeItem;
        beforeItem.Previous = item;
        this.Count++;
    }

    public void Remove(ListItem<T> item)
    {
        if (item == null)
        {
            throw new ArgumentNullException("Item can't be null.");
        }

        if (!this.Contains(item))
        {
            throw new InvalidOperationException("Node item isn't in the list.");
        }

        if (item.Previous != null && item.Next != null)
        {
            item.Previous.Next = item.Next;
            item.Next.Previous = item.Previous;
            item.Previous = null;
            item.Next = null;
            this.Count--;
        }
        else if (item.Previous == null)
        {
            this.RemoveFirst();
        }
        else if (item.Next == null)
        {
            this.RemoveLast();
        }
    }

    public bool Remove(T value)
    {
        var itemToRemove = this.Find(value);
        if (itemToRemove == null)
        {
            return false;
        }
        else
        {
            this.Remove(itemToRemove);
            return true;
        }
    }

    public bool Contains(T value)
    {
        foreach (var item in this)
        {
            if (item.CompareTo(value) == 0)
            {
                return true;
            }
        }
        return false;
    }

    public bool Contains(ListItem<T> item)
    {
        if (this.First == null)
        {
            return false;
        }

        ListItem<T> currentItem = this.First;
        if (item == currentItem)
        {
            return true;
        }
        while (currentItem.Next != null)
        {
            currentItem = currentItem.Next;
            if (item == currentItem)
            {
                return true;
            }
        }

        return false;
    }

    public ListItem<T> Find(T value)
    {
        if (this.First == null)
        {
            return null;
        }

        ListItem<T> item = this.First;
        if (item.Value.CompareTo(value) == 0)
        {
            return item;
        }

        while (item.Next != null)
        {
            item = item.Next;
            if (item.Value.CompareTo(value) == 0)
            {
                return item;
            }
        }

        return null;
    }

    public ListItem<T> FindLast(T value)
    {
        if (this.Last == null)
        {
            return null;
        }

        ListItem<T> item = this.Last;
        if (item.Value.CompareTo(value) == 0)
        {
            return item;
        }

        while (item.Previous != null)
        {
            item = item.Previous;
            if (item.Value.CompareTo(value) == 0)
            {
                return item;
            }
        }

        return null;
    }

    public IEnumerator<T> GetEnumerator()
    {
        ListItem<T> item = this.First;
        while (item != null)
        {
            yield return item.Value;
            item = item.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        foreach (var item in this)
        {
            result.Append(item + " <-> ");
        }
        result.Length -= 5;
        return result.ToString();
    }
}