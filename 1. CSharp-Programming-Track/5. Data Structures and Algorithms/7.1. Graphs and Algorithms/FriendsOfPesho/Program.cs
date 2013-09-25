using System;
using System.Collections.Generic;

class Program
{
    private static Dictionary<Node, List<Conection>> graph = new Dictionary<Node, List<Conection>>();
    private static Dictionary<int, Node> intToNode = new Dictionary<int, Node>();

    static void Main()
    {
        string[] inputNumbers = Console.ReadLine().Split(' ');

        int nodesCount = int.Parse(inputNumbers[0]);
        int streetsCount = int.Parse(inputNumbers[1]);
        int hospitalsCount = int.Parse(inputNumbers[2]);

        string[] allHospitals = Console.ReadLine().Split(' ');

        for (int i = 0; i < streetsCount; i++)
        {
            string[] currentStreet = Console.ReadLine().Split(' ');

            int firstId = int.Parse(currentStreet[0]);
            int secondId = int.Parse(currentStreet[1]);
            int distance = int.Parse(currentStreet[2]);

            if (!intToNode.ContainsKey(firstId))
            {
                intToNode.Add(firstId, new Node(firstId));
            }

            if (!intToNode.ContainsKey(secondId))
            {
                intToNode.Add(secondId, new Node(secondId));
            }

            Node first = intToNode[firstId];
            Node second = intToNode[secondId];

            if (!graph.ContainsKey(first))
            {
                graph[first] = new List<Conection>();
            }

            if (!graph.ContainsKey(second))
            {
                graph[second] = new List<Conection>();
            }

            graph[first].Add(new Conection(second, distance));
            graph[second].Add(new Conection(first, distance));
        }

        for (int i = 0; i < allHospitals.Length; i++)
        {
            int currentHospital = int.Parse(allHospitals[i]);
            intToNode[currentHospital].IsHospital = true;
        }

        long minDistance = long.MaxValue;
        for (int i = 0; i < allHospitals.Length; i++)
        {
            int currentHospital = int.Parse(allHospitals[i]);
            DijkstraAlgorithm(intToNode[currentHospital]);

            long currentDistance = 0;
            foreach (var item in intToNode)
            {
                if (!item.Value.IsHospital)
                {
                    currentDistance += item.Value.DijkstraDistance;
                }
            }

            if (currentDistance < minDistance)
            {
                minDistance = currentDistance;
            }
        }

        Console.WriteLine(minDistance);
    }

    static void DijkstraAlgorithm(Node source)
    {
        PriorityQueue<Node> queue = new PriorityQueue<Node>();

        foreach (var node in graph)
        {
            node.Key.DijkstraDistance = long.MaxValue;
        }

        source.DijkstraDistance = 0;
        queue.Enqueue(source);

        while (queue.Count != 0)
        {
            Node currentNode = queue.Dequeue();

            if (currentNode.DijkstraDistance == long.MaxValue)
            {
                break;
            }

            foreach (var connection in graph[currentNode])
            {
                long potDistance = currentNode.DijkstraDistance + connection.Distance;

                if (potDistance < connection.ToNode.DijkstraDistance)
                {
                    connection.ToNode.DijkstraDistance = potDistance;
                    queue.Enqueue(connection.ToNode);
                }
            }
        }
    }
}

class Node : IComparable
{
    public int Id { get; set; }
    public long DijkstraDistance { get; set; }
    public bool IsHospital { get; set; }

    public Node(int id, bool isHospital = false)
    {
        this.Id = id;
        this.IsHospital = isHospital;
    }

    public int CompareTo(object obj)
    {
        return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
    }
}

class Conection
{
    public Node ToNode { get; set; }
    public int Distance { get; set; }

    public Conection(Node toNode, int distance)
    {
        this.ToNode = toNode;
        this.Distance = distance;
    }
}

public class PriorityQueue<T> where T : IComparable
{
    private T[] heap;
    private int index;

    public int Count
    {
        get
        {
            return this.index - 1;
        }
    }

    public PriorityQueue()
    {
        this.heap = new T[16];
        this.index = 1;
    }

    public void Enqueue(T element)
    {
        if (this.index >= this.heap.Length)
        {
            IncreaseArray();
        }

        this.heap[this.index] = element;

        int childIndex = this.index;
        int parentIndex = childIndex / 2;
        this.index++;

        while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
        {
            T swapValue = this.heap[parentIndex];
            this.heap[parentIndex] = this.heap[childIndex];
            this.heap[childIndex] = swapValue;

            childIndex = parentIndex;
            parentIndex = childIndex / 2;
        }
    }

    public T Dequeue()
    {
        T result = this.heap[1];

        this.heap[1] = this.heap[this.Count];
        this.index--;

        int rootIndex = 1;

        int minChild;

        while (true)
        {
            int leftChildIndex = rootIndex * 2;
            int rightChildIndex = rootIndex * 2 + 1;

            if (leftChildIndex > this.index)
            {
                break;
            }
            else if (rightChildIndex > this.index)
            {
                minChild = leftChildIndex;
            }
            else
            {
                if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                {
                    minChild = leftChildIndex;
                }
                else
                {
                    minChild = rightChildIndex;
                }
            }

            if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
            {
                T swapValue = this.heap[rootIndex];
                this.heap[rootIndex] = this.heap[minChild];
                this.heap[minChild] = swapValue;

                rootIndex = minChild;
            }
            else
            {
                break;
            }
        }

        return result;
    }

    public T Peek()
    {
        return this.heap[1];
    }

    private void IncreaseArray()
    {
        T[] copiedHeap = new T[this.heap.Length * 2];

        for (int i = 0; i < this.heap.Length; i++)
        {
            copiedHeap[i] = this.heap[i];
        }

        this.heap = copiedHeap;
    }
}