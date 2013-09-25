using System;
using System.Collections.Generic;

public class Tree<T>
{
    private Node<T> root;
    private List<Node<T>> children = new List<Node<T>>();

    public Tree(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Value can't be null.");
        }

        this.root = new Node<T>(value);
        this.children = new List<Node<T>>();
    }

    public Tree(T value, params Tree<T>[] children)
        : this(value)
    {
        foreach (Tree<T> child in children)
        {
            this.root.AddChild(child.root);
        }
    }
}