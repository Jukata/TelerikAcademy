using System;

public class ListItem<T> where T : IComparable<T>
{
    public T Value { get; set; }
    public ListItem<T> Next { get; set; }
    public ListItem<T> Previous { get; set; }

    public ListItem(T value)
    {
        this.Value = value;
    }
}