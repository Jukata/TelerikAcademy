using System;

class MissCat2011
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] votes = new int[10];
        for (int i = 0; i < n; i++)
        {
            int vote = int.Parse(Console.ReadLine());
            votes[vote - 1]++;
        }
        int maxVotes = 0;
        int winner = 0;
        for (int i = 0; i < 10; i++)
        {
            if (votes[i] > maxVotes)
            {
                maxVotes = votes[i];
                winner = i + 1;
            }
        }
        Console.WriteLine(winner);
    }
}

