using System;

namespace RefactorIfStatements
{
    public class Program
    {
        private const int MAX_X = 10;
        private const int MIN_X = -10;
        private const int MAX_Y = 20;
        private const int MIN_Y = -20;

        public static void Main()
        {
            int x = 5;
            int y = 10;

            bool inRange = x >= MIN_X && x <= MAX_X && y >= MIN_Y && y <= MAX_Y;
            bool shouldVisitCell = false;

            if (inRange && shouldVisitCell)
            {
                VisitCell(x, y);
            }
        }

        private static void VisitCell(int x, int y)
        {
            // ...
        }
    }
}
