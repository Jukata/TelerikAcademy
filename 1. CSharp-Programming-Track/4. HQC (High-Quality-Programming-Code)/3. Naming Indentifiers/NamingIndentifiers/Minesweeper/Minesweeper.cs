namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        private const char BombSymbol = '*';
        private const char NotOpenedCellSymbol = '?';
        private const char EmptyCellSymbol = '-';
        private const int NumberOfBombs = 20;
        private const int BoardRows = 10;
        private const int BoardCols = 10;
        private const int MaxTopScorers = 6;

        private static readonly List<Score> TopScores = new List<Score>(MaxTopScorers);
        private static readonly int MaxScore = (BoardRows * BoardCols) - NumberOfBombs;
        private static readonly Random Random = new Random();

        static void Main(string[] args)
        {
            char[,] gameField = CreateGameField();
            char[,] bombField = CreateBombField();

            int row = 0;
            int col = 0;
            int currentScore = 0;

            string command = string.Empty;

            bool newGame = true;
            bool stepOnBomb = false;
            bool win = false;

            do
            {
                if (newGame)
                {
                    PrintHelp();
                    PrintGameField(gameField);
                    newGame = false;
                }

                Console.Write("Enter row and col or command: ");
                command = Console.ReadLine().Trim();
                string[] coordinates = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (coordinates.Length == 2)
                {
                    if (int.TryParse(coordinates[0], out row) &&
                        int.TryParse(coordinates[1], out col) &&
                        row < BoardRows && col < BoardCols &&
                        row >= 0 && col >= 0)
                    {
                        command = "OpenCell";
                    }
                }

                switch (command)
                {
                    case "top":
                        {
                            PrintTopScores(TopScores);
                            break;
                        }
                    case "restart":
                        {
                            gameField = CreateGameField();
                            bombField = CreateBombField();
                            PrintGameField(gameField);
                            stepOnBomb = false;
                            newGame = false;
                            break;
                        }
                    case "exit":
                        {
                            Console.WriteLine("Goodbye!");
                            break;
                        }
                    case "OpenCell":
                        if (bombField[row, col] != BombSymbol)
                        {
                            if (bombField[row, col] == EmptyCellSymbol)
                            {
                                PrintSurroundingBombCount(gameField, bombField, row, col);
                                currentScore++;
                            }

                            if (currentScore == MaxScore)
                            {
                                win = true;
                            }
                            else
                            {
                                PrintGameField(gameField);
                            }
                        }
                        else
                        {
                            stepOnBomb = true;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("\nInvalid Command! Try again.\n");
                            break;
                        }
                }

                if (stepOnBomb)
                {
                    PrintGameField(bombField);

                    Console.Write("\nYou step on bomb. Your points: {0}. Enter your name: ", currentScore);
                    string playerName = Console.ReadLine();

                    Score currentPlayerScore = new Score(playerName, currentScore);
                    SavePlayerScore(currentPlayerScore);
                    PrintTopScores(TopScores);

                    gameField = CreateGameField();
                    bombField = CreateBombField();
                    currentScore = 0;
                    stepOnBomb = false;
                    newGame = true;
                }

                if (win)
                {
                    Console.WriteLine("\nCongratulations! You Won.");
                    PrintGameField(bombField);
                    Console.WriteLine("Enter your name: ");
                    string playerName = Console.ReadLine();

                    Score currentPlayerScore = new Score(playerName, currentScore);
                    TopScores.Add(currentPlayerScore);
                    PrintTopScores(TopScores);

                    gameField = CreateGameField();
                    bombField = CreateBombField();
                    currentScore = 0;
                    win = false;
                    newGame = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Just Minesweeper \u00A9");
            Console.Read();
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Let's play “Minesweeper”. Try to clear the field. Avoid mines.\nYou can type following commands:\n" +
                              "'top' shows top scores.\n" +
                              "'restart' restarts the game.\n" +
                              "'exit' exits the game.");
        }

        private static void PrintTopScores(List<Score> scores)
        {
            Console.WriteLine("\nPoints:");
            if (scores.Count > 0)
            {
                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, scores[i].Name, scores[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("There isn't top score players!\n");
            }
        }

        private static void PrintGameField(char[,] gameField)
        {
            int rows = BoardRows;
            int cols = BoardCols;

            Console.Write("\n   ");
            for (int col = 0; col < cols; col++)
            {
                Console.Write(" {0}", col);
            }

            Console.WriteLine("\n   {0}", new string('-', BoardCols * 2 + 1));

            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(string.Format("{0} ", gameField[row, col]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   {0}", new string('-', BoardCols * 2 + 1));
        }

        private static char[,] CreateGameField()
        {
            char[,] board = InitializeField(BoardRows, BoardCols, NotOpenedCellSymbol);
            return board;
        }

        private static char[,] CreateBombField()
        {
            char[,] bombField = InitializeField(BoardRows, BoardCols, EmptyCellSymbol);

            List<int> bombsLocation = RandomizeBombsLocation();

            foreach (int location in bombsLocation)
            {
                int currCol = location / BoardCols;
                int currRow = location % BoardCols;

                if (currRow == 0 && location != 0)
                {
                    currCol--;
                    currRow = BoardCols;
                }
                else
                {
                    currRow++;
                }

                bombField[currCol, currRow - 1] = BombSymbol;
            }

            return bombField;
        }

        private static char[,] InitializeField(int rows, int cols, char cellSymbol)
        {
            char[,] field = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = cellSymbol;
                }
            }

            return field;
        }

        private static List<int> RandomizeBombsLocation()
        {
            List<int> bombsLocation = new List<int>();
            int locationLimit = BoardRows * BoardCols;
            while (bombsLocation.Count < NumberOfBombs)
            {
                int bombLocation = Random.Next(locationLimit);
                if (!bombsLocation.Contains(bombLocation))
                {
                    bombsLocation.Add(bombLocation);
                }
            }

            return bombsLocation;
        }

        private static void PrintSurroundingBombCount(char[,] gameField, char[,] bombField, int row, int col)
        {
            char adjacentBombs = CalculateAdjacentBombs(bombField, row, col);
            bombField[row, col] = adjacentBombs;
            gameField[row, col] = adjacentBombs;
        }

        private static char CalculateAdjacentBombs(char[,] bombField, int row, int col)
        {
            int adjacentBombsCount = 0;
            int rows = BoardRows;
            int cols = BoardCols;

            // check top cell
            if (row - 1 >= 0)
            {
                if (bombField[row - 1, col] == BombSymbol)
                {
                    adjacentBombsCount++;
                }
            }

            // check bottom cell
            if (row + 1 < rows)
            {
                if (bombField[row + 1, col] == BombSymbol)
                {
                    adjacentBombsCount++;
                }
            }

            // check left cell
            if (col - 1 >= 0)
            {
                if (bombField[row, col - 1] == BombSymbol)
                {
                    adjacentBombsCount++;
                }
            }

            // check right cell
            if (col + 1 < cols)
            {
                if (bombField[row, col + 1] == BombSymbol)
                {
                    adjacentBombsCount++;
                }
            }

            // check top-left cell
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (bombField[row - 1, col - 1] == BombSymbol)
                {
                    adjacentBombsCount++;
                }
            }

            // check top-right cell
            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (bombField[row - 1, col + 1] == BombSymbol)
                {
                    adjacentBombsCount++;
                }
            }

            // check bottom-left cell
            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (bombField[row + 1, col - 1] == BombSymbol)
                {
                    adjacentBombsCount++;
                }
            }

            // check bottom-right cell
            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (bombField[row + 1, col + 1] == BombSymbol)
                {
                    adjacentBombsCount++;
                }
            }

            return char.Parse(adjacentBombsCount.ToString());
        }

        private static void SavePlayerScore(Score currentPlayerScore)
        {
            if (TopScores.Count < TopScores.Capacity - 1)
            {
                TopScores.Add(currentPlayerScore);
            }
            else
            {
                for (int index = 0; index < TopScores.Count; index++)
                {
                    if (currentPlayerScore.Points > TopScores[index].Points)
                    {
                        TopScores.Insert(index, currentPlayerScore);
                        TopScores.RemoveAt(TopScores.Count - 1);
                        break;
                    }
                }
            }

            TopScores.Sort((Score s1, Score s2) => s2.Name.CompareTo(s1.Name));
            TopScores.Sort((Score s1, Score s2) => s2.Points.CompareTo(s1.Points));
        }
    }
}
