using System;
using System.Collections.Generic;
using System.Linq;

class TreeTraversal
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        HashSet<Node<int>> nodes = new HashSet<Node<int>>();

        for (int i = 0; i < n - 1; i++)
        {
            string[] childParentPair = Console.ReadLine().Split(' ');
            int parent = int.Parse(childParentPair[0]);
            int child = int.Parse(childParentPair[1]);

            Node<int> currentChild = new Node<int>(child);
            Node<int> currentParent = new Node<int>(parent);

            foreach (Node<int> node in nodes)
            {
                if (node.Value == parent)
                {
                    currentParent = node;
                }
                if (node.Value == child)
                {
                    currentChild = node;
                }
            }

            currentParent.AddChild(currentChild);

            nodes.Add(currentParent);
            nodes.Add(currentChild);
        }
        Console.WriteLine(new string('-', 40));

        // a) Find the root
        Node<int> root = FindRoot(nodes);
        Console.WriteLine("Root - {0} ", root.Value);
        Console.WriteLine(new string('-', 40));

        // b) Find all leafs
        List<Node<int>> leafs = FindAllLeafs(nodes);
        Console.Write("Leafs - ");
        foreach (Node<int> leaf in leafs)
        {
            Console.Write(leaf.Value + " ");
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 40));

        // c) Find all middle nodes
        List<Node<int>> middleNodes = FindAllMiddleNodes(nodes);
        if (middleNodes.Count > 0)
        {
            Console.Write("Middle nodes - ");
            foreach (Node<int> middleNode in middleNodes)
            {
                Console.Write(middleNode.Value + " ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("There isn't middle nodes.");
        }
        Console.WriteLine(new string('-', 40));

        // d) Find the longest path in tree
        int longestPath = FindLongestPath(root);
        Console.WriteLine("Longest path - {0}", longestPath);
        Console.WriteLine(new string('-', 40));

        // e) All paths in tree with given sum
        // doesn't work properly 
        int sum = 6;
        List<string> allPaths = new List<string>();
        GetAllPathsWithGivenSum(root, sum, allPaths);
        if (allPaths.Count > 0)
        {
            Console.WriteLine("All paths with sum {0} :", sum);
            foreach (string path in allPaths)
            {
                Console.WriteLine("{0} = {1}", path, sum);
            }
            Console.WriteLine(new string('-', 40));
        }

        // f) All subtrees with given sum S of their nodes
        sum = 15;
        List<List<Node<int>>> subtrees = GetSubtreesWithGivenSum(nodes.ToList(), sum);
        if (subtrees.Count > 0)
        {
            Console.WriteLine("Subtrees with sum {0} :", sum);
            for (int i = 0; i < subtrees.Count; i++)
            {
                for (int j = 0; j < subtrees[i].Count; j++)
                {
                    if (j < subtrees[i].Count - 1)
                    {
                        Console.Write("{0} + ", subtrees[i][j].Value);
                    }
                    else
                    {
                        Console.Write("{0} ", subtrees[i][j].Value);
                    }
                }
                Console.WriteLine("= {0}", sum);
            }
            Console.WriteLine(new string('-', 40));
        }


        Console.WriteLine("Beshkov: ");
        FindPathsWithSum(root, 8);
        PrintPaths();
    }

    static List<Node<int>> currentPath = new List<Node<int>>();
    static List<List<Node<int>>> paths = new List<List<Node<int>>>();
    static int currentSum = 0;
    public static void FindPathsWithSum(Node<int> node, int targetSum)
    {
        currentSum += node.Value;
        currentPath.Add(node);
        if (currentSum == targetSum)
        {
            List<Node<int>> copy = new List<Node<int>>(currentPath);
            paths.Add(copy);

        }
        foreach (var item in node.Children)
        {
            FindPathsWithSum(item, targetSum);
        }
        currentPath.RemoveAt(currentPath.Count - 1);
        currentSum -= node.Value;

    }

    public static void PrintPaths()
    {
        foreach (var path in paths)
        {
            foreach (Node<int> node in path)
            {
                Console.Write(node.Value + "->");
            }
            Console.WriteLine();
        }
    }

    private static void GetAllPathsWithGivenSum(Node<int> root, int sum, List<string> allPaths)
    {
        List<int> currentPath = new List<int>();
        Stack<Node<int>> stack = new Stack<Node<int>>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var currentNode = stack.Pop();
            currentPath.Add(currentNode.Value);
            if (currentPath.Sum() == sum)
            {
                string path = string.Join(" + ", currentPath);
                allPaths.Add(path);
            }
            if (currentNode.ChildrenCount == 0)
            {
                currentPath.RemoveAt(currentPath.Count - 1);
            }
            foreach (Node<int> child in currentNode.Children)
            {
                stack.Push(child);
                GetAllPathsWithGivenSum(child, sum, allPaths);
            }
        }
    }

    private static List<List<Node<int>>> GetSubtreesWithGivenSum(List<Node<int>> nodes, int expectedSum)
    {
        List<List<Node<int>>> subtrees = new List<List<Node<int>>>();

        int maxI = 1 << nodes.Count; //(int)Math.Pow(2, nodes.Count);
        for (int i = 0; i < maxI; i++)
        {
            int currentSum = 0;
            List<Node<int>> currentTree = new List<Node<int>>();
            for (int j = 0; j < nodes.Count; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    currentSum += nodes[j].Value;
                    currentTree.Add(nodes[j]);
                }
            }
            if (currentSum == expectedSum && IsValidTree(currentTree))
            {
                subtrees.Add(currentTree);
            }
        }

        return subtrees;
    }

    private static bool IsValidTree(List<Node<int>> currentPath)
    {
        int rootsCount = 0;
        foreach (Node<int> node in currentPath)
        {
            bool isRoot = true;
            foreach (Node<int> item in currentPath)
            {
                if (item == node.Parent)
                {
                    isRoot = false;
                    break;
                }
            }
            if (isRoot)
            {
                rootsCount++;
            }
            if (rootsCount > 1)
            {
                return false;
            }
        }
        return true;
    }

    private static Node<int> FindRoot(IEnumerable<Node<int>> nodes)
    {
        foreach (Node<int> node in nodes)
        {
            if (!node.HasParent)
            {
                return node;
            }
        }

        throw new ArgumentException("The tree hasn't root.", "nodes");
    }

    private static List<Node<int>> FindAllLeafs(IEnumerable<Node<int>> nodes)
    {
        List<Node<int>> leafs = new List<Node<int>>();
        foreach (Node<int> node in nodes)
        {
            if (node.ChildrenCount == 0)
            {
                leafs.Add(node);
            }
        }

        if (leafs.Count == 0)
        {
            throw new ArgumentException("The tree hasn't leafs.", "nodes");
        }

        return leafs;
    }

    private static List<Node<int>> FindAllMiddleNodes(IEnumerable<Node<int>> nodes)
    {
        List<Node<int>> middleNodes = new List<Node<int>>();
        foreach (Node<int> node in nodes)
        {
            if (node.HasParent && node.ChildrenCount > 0)
            {
                middleNodes.Add(node);
            }
        }

        return middleNodes;
    }

    private static int FindLongestPath(Node<int> root)
    {
        if (root.ChildrenCount == 0)
        {
            return 0;
        }

        int maxPath = 0;
        foreach (Node<int> child in root.Children)
        {
            int currentPath = FindLongestPath(child);
            if (currentPath > maxPath)
            {
                maxPath = currentPath;
            }
        }

        return maxPath + 1;
    }
}