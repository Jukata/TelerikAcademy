using System;

class EightQueensPuzzle
{
    private const char QueenSymbol = 'Q';
    private const char EmptyCellSymbol = '_';
    private const int BoardSize = 8;
    private static int totalSolutionsCount = 0;
    private static char[,] board;
    private static bool[] usedRows = new bool[BoardSize];
    private static bool[] usedCols = new bool[BoardSize];
    private static bool[] usedPrimaryDiagonals = new bool[BoardSize * 2 - 1];
    private static bool[] usedSecondaryDiagonals = new bool[BoardSize * 2 - 1];

    private static void Main()
    {
        board = new char[BoardSize, BoardSize];
        for (int row = 0; row < BoardSize; row++)
        {
            for (int col = 0; col < BoardSize; col++)
            {
                board[row, col] = EmptyCellSymbol;
            }
        }

        PlaceQueen(0);
        Console.WriteLine("Total solutions: {0}", totalSolutionsCount);
    }

    private static void PlaceQueen(int queenNumber)
    {

        if (queenNumber == BoardSize)
        {
            //Uncomment to print each solution
            Console.WriteLine("Solution: ");
            PrintBoard();
            Console.ReadLine();
            Console.Clear();

            totalSolutionsCount++;
            return;
        }

        for (int i = 0; i < BoardSize; i++)
        {
            if (IsValidPlace(queenNumber, i))
            {
                MarkCell(queenNumber, i, true);
                board[queenNumber, i] = QueenSymbol;
                PlaceQueen(queenNumber + 1);
                board[queenNumber, i] = EmptyCellSymbol;
                MarkCell(queenNumber, i, false);
            }
        }
    }

    private static void MarkCell(int row, int col, bool state)
    {
        usedRows[row] = state;
        usedCols[col] = state;

        int primaryDiagonalIndex = CalcPrimaryDiagonalIndex(row, col);
        usedPrimaryDiagonals[primaryDiagonalIndex] = state;

        int secondaryDiagonalIndex = CalcSecondaryDiagonalIndex(col, row);
        usedSecondaryDiagonals[secondaryDiagonalIndex] = state;
    }

    private static int CalcPrimaryDiagonalIndex(int row, int col)
    {
        int diagonalIndex = row - col;

        if (diagonalIndex < 0)
        {
            diagonalIndex = BoardSize + (diagonalIndex * -1) - 1;
        }

        return diagonalIndex;
    }

    private static int CalcSecondaryDiagonalIndex(int col, int row)
    {
        int diagonalIndex = row + col;
        return diagonalIndex;
    }

    private static void PrintBoard()
    {
        for (int row = 0; row < board.GetLength(0); row++)
        {
            Console.Write("|");
            for (int col = 0; col < board.GetLength(1); col++)
            {

                Console.Write(board[row, col] + "|");
            }
            Console.WriteLine();
            //Console.WriteLine("{0}{1}", Environment.NewLine, new string('-', BoardSize * 2 + 1));
        }
    }

    private static bool IsValidPlace(int row, int col)
    {
        int primaryDiagonalIndex = CalcPrimaryDiagonalIndex(row, col);
        int secondaryDiagonalIndex = CalcSecondaryDiagonalIndex(col, row);

        if (usedRows[row] || usedCols[col] || usedPrimaryDiagonals[primaryDiagonalIndex]
            || usedSecondaryDiagonals[secondaryDiagonalIndex])
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}