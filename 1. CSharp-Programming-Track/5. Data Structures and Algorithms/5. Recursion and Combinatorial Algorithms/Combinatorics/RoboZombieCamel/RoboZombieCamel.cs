using System;
using System.Linq;
using System.Numerics;

class RoboZombieCamel
{
    // http://bgcoder.com/Contest/Practice/59 - Task10

    private static BigInteger answerModul = 18446744073709551615;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] distances = new int[n];

        for (int i = 0; i < n; i++)
        {
            string inputCoords = Console.ReadLine();
            string[] obeliskCoordinates = inputCoords.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            // ninja fix
            if (obeliskCoordinates.Length != 2) { i--; continue; }

            distances[i] = CalcDistance(int.Parse(obeliskCoordinates[0]), int.Parse(obeliskCoordinates[1]));
        }

        BigInteger conectionTimesPerObelisk = 1;
        BigInteger sum = 0;
        for (int i = 0; i < distances.Length; i++)
        {
            sum += distances[i];
            conectionTimesPerObelisk *= 2;
        }
        conectionTimesPerObelisk /= 2;

        BigInteger totalDistance = sum * conectionTimesPerObelisk;
        Console.WriteLine(totalDistance % ++answerModul);
    }

    private static int CalcDistance(int x, int y)
    {
        if (x < 0)
        {
            x *= -1;
        }

        if (y < 0)
        {
            y *= -1;
        }

        int distance = x + y;
        return distance;
    }
}