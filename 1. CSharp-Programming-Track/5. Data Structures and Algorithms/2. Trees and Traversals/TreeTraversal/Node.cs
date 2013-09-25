using System;
using System.Collections.Generic;
using System.Linq;

public class Node<T>
{
    private List<Node<T>> children;

    public Node<T> Parent { get; set; }

    public T Value { get; private set; }

    public bool HasParent { get; private set; }

    public int ChildrenCount
    {
        get { return this.children.Count; }
    }

    public List<Node<T>> Children
    {
        get
        {
            List<Node<T>> readOnlyChildren = this.children.AsReadOnly().ToList();
            return readOnlyChildren;
        }
    }

    public Node(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Value can't be null.");
        }

        this.Value = value;
        this.children = new List<Node<T>>();
    }

    public void AddChild(Node<T> child)
    {
        if (child == null)
        {
            throw new ArgumentNullException("Child can't be null.");
        }

        if (child.HasParent)
        {
            throw new ArgumentException("Node already has parent.");
        }

        child.Parent = this;
        child.HasParent = true;
        this.children.Add(child);
    }

    public Node<T> GetChild(int index)
    {
        return this.children[index];
    }
}
