using System;
using System.Collections.Generic;

public class Labyrinth
{
    private const string AllowedMove = "0";
    private const string StartPosition = "*";
    private const string Unreacheble = "u";

    static void Main()
    {
        string[,] labyrinth = 
        {
            {"0", "0","0","X","0","X"},
            {"0", "X","0","X","0","X"},
            {"0", "*","X","0","X","0"},
            {"0", "X","0","0","0","0"},
            {"0", "0","0","X","X","0"},
            {"0", "0","0","X","0","X"},
        };

        //FillWithDFS(labyrinth); // wrong algorithm for current task =)
        FillWithBFS(labyrinth);
        Print(labyrinth);
    }

    private static void FillWithBFS(string[,] labyrinth)
    {
        if (labyrinth == null)
        {
            throw new ArgumentException("Labyrinth can't be null.");
        }

        int startRow = -1;
        int startCol = -1;

        if (!FindStartRowAndCol(labyrinth, ref startRow, ref startCol))
        {
            throw new ArgumentException("Labyrinth don't have start position.");
        }

        FillReachableBFS(labyrinth, startRow, startCol);
        FillUnreachable(labyrinth);
    }

    private static void FillReachableBFS(string[,] labyrinth, int startRow, int startCol)
    {
        Coordinate[] directions = 
        {
            new Coordinate(1,0),
            new Coordinate(0,1),
            new Coordinate(-1,0),
            new Coordinate(0,-1)
        };

        Coordinate startPosition = new Coordinate(startRow, startCol);
        Queue<KeyValuePair<Coordinate, int>> queue = new Queue<KeyValuePair<Coordinate, int>>();

        var item = new KeyValuePair<Coordinate, int>(startPosition, 0);
        queue.Enqueue(item);

        while (queue.Count > 0)
        {
            var currentItem = queue.Dequeue();
            Coordinate currentPosition = currentItem.Key;
            int depth = currentItem.Value;

            if (depth != 0)
            {
                labyrinth[currentPosition.X, currentPosition.Y] = depth.ToString();
            }

            foreach (Coordinate dir in directions)
            {
                Coordinate newPosition = dir + currentPosition;
                if (IsValidMove(labyrinth, newPosition.X, newPosition.Y))
                {
                    var newItem = new KeyValuePair<Coordinate, int>(newPosition, depth + 1);
                    queue.Enqueue(newItem);
                }
            }
        }
    }

    private class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Coordinate operator +(Coordinate c1, Coordinate c2)
        {
            Coordinate newCoord = new Coordinate(c1.X + c2.X, c1.Y + c2.Y);
            return newCoord;
        }

        public static Coordinate operator -(Coordinate c1, Coordinate c2)
        {
            Coordinate newCoord = new Coordinate(c1.X - c2.X, c1.Y - c2.Y);
            return newCoord;
        }
    }

    //public static void FillWithDFS(string[,] labyrinth)
    //{
    //    if (labyrinth == null)
    //    {
    //        throw new ArgumentException("Labyrinth can't be null.");
    //    }

    //    int startRow = -1;
    //    int startCol = -1;

    //    if (!FindStartRowAndCol(labyrinth, ref startRow, ref startCol))
    //    {
    //        throw new ArgumentException("Labyrinth don't have start position.");
    //    }

    //    FillReachableDFS(labyrinth, startRow, startCol, 0);
    //    FillUnreachable(labyrinth);
    //}

    //private static void FillReachableDFS(string[,] labyrinth, int currentRow, int currentCol, int depth)
    //{
    //    if (depth != 0) labyrinth[currentRow, currentCol] = depth.ToString();

    //    if (IsValidMove(labyrinth, currentRow + 1, currentCol))
    //    {
    //        FillReachable(labyrinth, currentRow + 1, currentCol, depth + 1);
    //    }

    //    if (IsValidMove(labyrinth, currentRow, currentCol + 1))
    //    {
    //        FillReachable(labyrinth, currentRow, currentCol + 1, depth + 1);
    //    }

    //    if (IsValidMove(labyrinth, currentRow - 1, currentCol))
    //    {
    //        FillReachable(labyrinth, currentRow - 1, currentCol, depth + 1);
    //    }

    //    if (IsValidMove(labyrinth, currentRow, currentCol - 1))
    //    {
    //        FillReachable(labyrinth, currentRow, currentCol - 1, depth + 1);
    //    }
    //}

    private static bool IsValidMove(string[,] labyrinth, int currentRow, int currentCol)
    {
        if (currentRow >= 0 && currentRow < labyrinth.GetLength(0)
            && currentCol >= 0 && currentCol < labyrinth.GetLength(1)
            && labyrinth[currentRow, currentCol] == AllowedMove)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static bool FindStartRowAndCol(string[,] labyrinth, ref int startRow, ref int startCol)
    {
        for (int row = 0; row < labyrinth.GetLength(0); row++)
        {
            for (int col = 0; col < labyrinth.GetLength(1); col++)
            {
                if (labyrinth[row, col] == StartPosition)
                {
                    startRow = row;
                    startCol = col;
                    return true;
                }
            }
        }
        return false;
    }

    private static void FillUnreachable(string[,] labyrinth)
    {
        for (int row = 0; row < labyrinth.GetLength(0); row++)
        {
            for (int col = 0; col < labyrinth.GetLength(1); col++)
            {
                if (labyrinth[row, col] == AllowedMove)
                {
                    labyrinth[row, col] = Unreacheble;
                }
            }
        }
    }

    private static void Print(string[,] labyrinth)
    {
        for (int row = 0; row < labyrinth.GetLength(0); row++)
        {
            Console.Write("[");
            for (int col = 0; col < labyrinth.GetLength(1); col++)
            {
                Console.Write("{0,-3} ", labyrinth[row, col]);
            }
            Console.WriteLine("]");
        }
    }
}

