using System;
using System.Threading;
using System.Collections.Generic;

class FallingRocks
{
    class rock
    {
        public int xCoord;
        public int yCoord;
        public int size;
        public ConsoleColor color;
        public char rockSymbol;

        internal rock()
        {
            size = randomGenerator.Next(0, 5);
            bool rockCollision;
            do
            {
                rockCollision = false;
                xCoord = randomGenerator.Next(0, Console.WindowWidth - size);
                foreach (rock rock in rocksList)
                {
                    if (rock.yCoord == 0)
                    {
                        if (rock.xCoord + rock.size - 10 < xCoord || rock.xCoord > xCoord + size - 10)
                        {
        //  if (!(rock.xCoord + rock.size - 1 < dwarfPosition || rock.xCoord > dwarfPosition + dwarfSize - 1))
                            rockCollision = false;
                        }
                    }
                }
            } while (rockCollision);
            yCoord = 3;
            int randomColorGenerator = randomGenerator.Next(0, 10);
            switch (randomColorGenerator)
            {
                case 0: color = ConsoleColor.DarkGreen; break;
                case 1: color = ConsoleColor.DarkMagenta; break;
                case 2: color = ConsoleColor.DarkYellow; break;
                case 3: color = ConsoleColor.Yellow; break;
                case 4: color = ConsoleColor.DarkGreen; break;
                case 5: color = ConsoleColor.Magenta; break;
                case 6: color = ConsoleColor.Green; break;
                case 7: color = ConsoleColor.DarkCyan; break;
                case 8: color = ConsoleColor.Cyan; break;
                case 9: color = ConsoleColor.Blue; break;
                case 10: color = ConsoleColor.DarkBlue; break;
                case 11: color = ConsoleColor.DarkGray; break;
                case 12: color = ConsoleColor.White; break;
                case 13: color = ConsoleColor.DarkRed; break;
                default: color = ConsoleColor.White; break;
            }
            rockSymbol = rockSymbols[randomGenerator.Next(0, 10)];
        }
        internal void Down()
        {
            yCoord++;
        }
    }

    static List<rock> rocksList = new List<rock>();
    static char[] rockSymbols = { '^', '@', '*', '&', '+', '%', '$', '#', '.', ';', '-' };
    static Random randomGenerator = new Random();
    static int dwarfSize = 3;
    static int dwarfPosition;
    static int lives = 3;
    static int points = 0;
    static bool gameOver = false;
    static int gameSpeed = 200;

    static void SetInitialPosition()
    {
        dwarfPosition = Console.WindowWidth / 2 - dwarfSize / 2;
    }

    static void printDwarf()
    {
        ConsoleColor dwarfColor = ConsoleColor.Red;
        for (int i = dwarfPosition; i < dwarfPosition + dwarfSize; i++)
        {
            if (i < dwarfPosition + dwarfSize / 2)
            {
                Print(i, Console.WindowHeight - 2, '(', dwarfColor);
            }
            else if (i == dwarfPosition + dwarfSize / 2)
            {
                Print(i, Console.WindowHeight - 2, '0', dwarfColor);
            }
            else
            {
                Print(i, Console.WindowHeight - 2, ')', dwarfColor);
            }
        }
        //for (int i = 0; i < dwarfSize; i++)
        //{
        //    if (i < (dwarfSize + 1) / 2)
        //    {
        //        Print(dwarfPosition + i, Console.WindowHeight - 2, '(');
        //    }
        //    else if (i == (dwarfSize + 1) / 2)
        //    {
        //        Print(dwarfPosition, Console.WindowHeight - 2, '0');
        //    }
        //    else
        //    {
        //        Print(dwarfPosition + i, Console.WindowHeight - 2, ')');
        //    }
        //}
    }

    static void createNewRocks()
    {
        if (randomGenerator.Next(0, 100) < 50) // 50% for empty line
        {

            int rocksNumber = randomGenerator.Next(1, 4);

            for (int i = 0; i < rocksNumber; i++)
            {
                rocksList.Add(new rock());
            }
        }
    }

    static void printRocks()
    {
        int indexOfRock = 0;
        while (indexOfRock < rocksList.Count)
        {
            if (rocksList[indexOfRock].yCoord < Console.WindowHeight - 1)
            {
                for (int i = 0; i < rocksList[indexOfRock].size; i++)
                {
                    Print(rocksList[indexOfRock].xCoord + i, rocksList[indexOfRock].yCoord, rocksList[indexOfRock].rockSymbol, rocksList[indexOfRock].color);
                }
                rocksList[indexOfRock].Down();
            }
            else
            {
                points += rocksList[indexOfRock].size * 10;
                rocksList.Remove(rocksList[indexOfRock]);
            }
            indexOfRock++;
        }
        //randomGenerator.Next(0, 10);
        //for (int i = 0; i < rand; i++)
        //{

        //}
    }

    static void moveDwarfLeft()
    {
        if (dwarfPosition > 0)
        {
            dwarfPosition--;
        }
    }
    static void moveDwarfRight()
    {
        if (dwarfPosition + dwarfSize < Console.WindowWidth)
        {
            dwarfPosition++;
        }
    }

    static void collision()
    {
        foreach (rock rock in rocksList)
        {
            if (rock.yCoord == Console.WindowHeight - 2)
            {
                if (!(rock.xCoord + rock.size - 1 < dwarfPosition || rock.xCoord > dwarfPosition + dwarfSize - 1))
                {
                    // collision
                    lives--;
                    if (lives < 0)
                    {
                        gameOver = true;
                    }
                    Console.SetCursorPosition(dwarfPosition, Console.WindowHeight - 2);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("boom");
                    Thread.Sleep(250);
                    rocksList.Clear();
                    SetInitialPosition();
                    break;
                }
            }
        }
    }

    static void gainNewLife()
    {
        if (points > 30 && points % 10000 < 30) // bonus life on every 10000 points
        {
            points += 30;
            lives++;
        }
    }

    static void printGrass()
    {
        Console.SetCursorPosition(0, Console.WindowHeight - 1);
        Console.BackgroundColor = ConsoleColor.Green;
        Console.Write(new string('^', 80));
        Console.BackgroundColor = ConsoleColor.Black;
    }
    static void printInfo()
    {
        Console.SetCursorPosition(3, 0);
        Console.WriteLine("Falling Rocks:");
        Console.SetCursorPosition(18, 0);
        Console.WriteLine("Left/right = move. Up/down = change game speed. Esc = exit.");
        Console.SetCursorPosition(10, 1);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Score:{0}", points);
        Console.SetCursorPosition(50, 1);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Lives = {0}", lives);
        Console.SetCursorPosition(0, 2);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(new string('-', 80));
    }

    static void Print(int col, int row, char symbol, ConsoleColor color)
    {
        Console.SetCursorPosition(col, row);
        Console.ForegroundColor = color;
        Console.Write(symbol);
    }

    static void Main()
    {
        Console.BufferWidth = Console.WindowWidth;
        Console.BufferHeight = Console.WindowHeight;
        while (true)
        {
            Console.Clear();
            Console.Write("Press enter to play new game or esc to exit.");
            ConsoleKeyInfo menuChoice = Console.ReadKey();
            if (menuChoice.Key == ConsoleKey.Enter)
            {
                lives = 3;
                points = 0;
                gameSpeed = 200;
                gameOver = false;
                rocksList.Clear();
                SetInitialPosition();
                while (true)
                {
                    bool enterMenu = false;
                    while (Console.KeyAvailable) // move dwarf
                    {
                        ConsoleKeyInfo pushButton = Console.ReadKey();
                        if (pushButton.Key == ConsoleKey.LeftArrow)
                        {
                            moveDwarfLeft();
                        }
                        else if (pushButton.Key == ConsoleKey.RightArrow)
                        {
                            moveDwarfRight();
                        }
                        else if (pushButton.Key == ConsoleKey.Escape)
                        {
                            enterMenu = true;
                            break;
                        }
                        else if (pushButton.Key == ConsoleKey.UpArrow)
                        {
                            if (gameSpeed > 1)
                            {
                                gameSpeed -= 10; // this is thread sleep in milliseconds}
                            }
                        }
                        else if (pushButton.Key == ConsoleKey.DownArrow)
                        {
                            gameSpeed += 10; // this is thread sleep in milliseconds
                        }
                    }
                    if (enterMenu)
                    {
                        break;
                    }
                    printGrass();
                    printDwarf();
                    createNewRocks();
                    printRocks();
                    printInfo();
                    collision();
                    if (gameOver)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Score:{0}", points);
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 + 1);
                        Console.WriteLine("Game Over!");
                        Thread.Sleep(1000);
                        Console.ReadKey();
                        break;
                    }
                    gainNewLife();
                    Thread.Sleep(gameSpeed);
                    Console.Clear();
                }
            }
            else if (menuChoice.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine("Thanks for playing.");
                break;
            }
        }
    }
}

