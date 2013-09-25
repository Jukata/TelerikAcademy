using System;

class FindAllConnectedAreas
{
    private static char[,] labyrinth;
    private static bool[,] visited;
    private const char PassableSymbol = ' ';

    private static void Main()
    {
        labyrinth = new char[5, 5]
        {
            {' ', '#', ' ',' ', ' '},
            {' ', '#', '#','#', '#'},
            {' ', '#', ' ',' ', ' '},
            {' ', ' ', ' ','#', ' '},
            {'#', '#', '#','#', '#'},
        };

        int rowsCount = labyrinth.GetLength(0);
        int colsCount = labyrinth.GetLength(1);

        visited = new bool[rowsCount, colsCount];

        for (int row = 0; row < rowsCount; row++)
        {
            for (int col = 0; col < colsCount; col++)
            {
                if (labyrinth[row, col] == PassableSymbol && !visited[row, col])
                {
                    int count = FindConnectedArea(row, col);

                    Console.WriteLine("Connected area of cells {0}", count);
                }
            }
        }
    }

    private static int FindConnectedArea(int currentRow, int currentCol)
    {
        if (!IsInLabyrinth(currentRow, currentCol))
        {
            return 0;
        }

        if (labyrinth[currentRow, currentCol] != ' ')
        {
            return 0;
        }

        if (visited[currentRow, currentCol])
        {
            return 0;
        }

        visited[currentRow, currentCol] = true;
        int count = 0;

        count += FindConnectedArea(currentRow, currentCol - 1);
        count += FindConnectedArea(currentRow - 1, currentCol);
        count += FindConnectedArea(currentRow, currentCol + 1);
        count += FindConnectedArea(currentRow + 1, currentCol);

        return 1 + count;
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