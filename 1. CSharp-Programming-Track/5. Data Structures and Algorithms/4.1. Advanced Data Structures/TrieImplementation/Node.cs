using System;
using System.Collections.Generic;
using System.Linq;

public class Node
{
    private char letter;
    private bool last;
    private Dictionary<char, Node> children;

    public Node(char ch)
    {
        children = new Dictionary<char, Node>();
        this.last = false;
        this.letter = ch;
    }

    public char Letter
    {
        get { return this.letter; }
        set { this.letter = value; }
    }

    public bool Last
    {
        get { return this.last; }
        set { this.last = value; }
    }

    public Dictionary<char, Node> Children
    {
        get { return this.children; }
        set { this.children = value; }
    }

    public Node ChildNode(char ch)
    {
        if (Children != null)
        {
            if (Children.ContainsKey(ch))
            {
                return Children[ch];
            }
        }
        return null;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }

        return Equals(obj);
    }

    public bool Equals(Node obj)
    {
        if (obj != null && obj.Letter == this.Letter)
        {
            return true;
        }

        return false;
    }

    public override int GetHashCode()
    {
        int hash = 13;
        hash = (hash * 7) + this.Letter.GetHashCode();
        return hash;
    }
}