using System;
using System.Collections.Generic;

class AllPathsBetweenTwoCells
{
    //We are given a matrix of passable and non-passable cells. Write a 
    //recursive program for finding all paths between two cells in the matrix.

    private static char[,] labyrinth;

    private const char VisitedSymbol = 'v';
    private const char UnpassableSymbol = '#';
    private const char PassableSymbol = ' ';
    private const char ExitSymbol = 'e';
    private const char Up = 'U';
    private const char Down = 'D';
    private const char Left = 'L';
    private const char Right = 'R';

    static void Main()
    {
        labyrinth = new char[5, 5]
        {
            {' ', '#', ' ',' ', ' '},
            {' ', '#', ' ','#', ' '},
            {' ', '#', ' ',' ', ' '},
            {' ', ' ', ' ','#', ' '},
            {'#', '#', '#','#', '#'},
        };

        FindAllPathsBetweenTwoCells(0, 0, 3, 4);
    }

    private static void FindAllPathsBetweenTwoCells(int startRow, int startCol, int exitRow, int exitCol)
    {
        if (!IsInLabyrinth(startRow, startCol) || !IsInLabyrinth(exitRow, exitCol)) //not valid start and exit cells
        {
            return;
        }

        if (labyrinth[startRow, startCol] == UnpassableSymbol) // start on unpassable cell
        {
            return;
        }

        labyrinth[exitRow, exitCol] = ExitSymbol;
        FindAllPaths(startRow, startCol, new List<char>());
    }

    private static void FindAllPaths(int currentRow, int currentCol, List<char> currentPath)
    {
        if (!IsInLabyrinth(currentRow, currentCol))
        {
            return;
        }

        if (labyrinth[currentRow, currentCol] == ExitSymbol)
        {
            PrintPath(currentPath);
            return;
        }

        if (labyrinth[currentRow, currentCol] != PassableSymbol)
        {
            return;
        }

        labyrinth[currentRow, currentCol] = VisitedSymbol;

        currentPath.Add(Left);
        FindAllPaths(currentRow, currentCol - 1, currentPath);
        currentPath.RemoveAt(currentPath.Count - 1);

        currentPath.Add(Up);
        FindAllPaths(currentRow - 1, currentCol, currentPath);
        currentPath.RemoveAt(currentPath.Count - 1);

        currentPath.Add(Right);
        FindAllPaths(currentRow, currentCol + 1, currentPath);
        currentPath.RemoveAt(currentPath.Count - 1);

        currentPath.Add(Down);
        FindAllPaths(currentRow + 1, currentCol, currentPath);
        currentPath.RemoveAt(currentPath.Count - 1);

        labyrinth[currentRow, currentCol] = PassableSymbol;
    }

    private static void PrintPath(List<char> currentPath)
    {
        Console.WriteLine("Path found: ");
        for (int i = 0; i < labyrinth.GetLength(0); i++)
        {
            for (int j = 0; j < labyrinth.GetLength(1); j++)
            {
                Console.Write(labyrinth[i, j] + "|");
            }
            Console.WriteLine();
        }
        Console.WriteLine(string.Join("", currentPath));
        Console.WriteLine(new string('-', 20));
    }

    private static bool IsInLabyrinth(int row, int col)
    {
        if (row >= 0 && row < labyrinth.GetLength(0) && col >= 0 && col < labyrinth.GetLength(1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

