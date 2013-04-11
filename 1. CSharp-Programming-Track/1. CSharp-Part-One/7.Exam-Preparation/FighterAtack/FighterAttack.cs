using System;

class FighterAttack
{
    static void Main()
    {
        int Px1 = int.Parse(Console.ReadLine());
        int Py1 = int.Parse(Console.ReadLine());
        int Px2 = int.Parse(Console.ReadLine());
        int Py2 = int.Parse(Console.ReadLine());
        int Fx = int.Parse(Console.ReadLine());
        int Fy = int.Parse(Console.ReadLine());
        int D = int.Parse(Console.ReadLine());

        int left = Math.Min(Px1, Px2);
        int right = Math.Max(Px1, Px2);
        int top = Math.Max(Py1, Py2);
        int bottom = Math.Min(Py1, Py2);

        int damage = 0;

        if (Fx + D >= left && Fx + D <= right && Fy >= bottom && Fy <= top)
        {
            damage += 100;
        }
        if (Fx + D + 1 >= left && Fx + D + 1 <= right && Fy >= bottom && Fy <= top)
        {
            damage += 75;
        }
        if (Fx + D >= left && Fx + D <= right && Fy + 1 >= bottom && Fy + 1 <= top)
        {
            damage += 50;
        }
        if (Fx + D >= left && Fx + D <= right && Fy - 1 >= bottom && Fy - 1 <= top)
        {
            damage += 50;
        }
        Console.WriteLine(damage + "%");
    }
}

