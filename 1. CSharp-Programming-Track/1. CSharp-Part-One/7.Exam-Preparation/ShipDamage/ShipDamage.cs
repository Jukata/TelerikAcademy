using System;

class ShipDamage
{
    static void Main()
    {
        int Sx1 = int.Parse(Console.ReadLine());
        int Sy1 = int.Parse(Console.ReadLine());
        int Sx2 = int.Parse(Console.ReadLine());
        int Sy2 = int.Parse(Console.ReadLine());

        int H = int.Parse(Console.ReadLine());

        int Cx1 = int.Parse(Console.ReadLine());
        int Cy1 = int.Parse(Console.ReadLine());
        int Cx2 = int.Parse(Console.ReadLine());
        int Cy2 = int.Parse(Console.ReadLine());
        int Cx3 = int.Parse(Console.ReadLine());
        int Cy3 = int.Parse(Console.ReadLine());

        Cy1 = H + H - Cy1;
        Cy2 = H + H - Cy2;
        Cy3 = H + H - Cy3;

        int left = Math.Min(Sx1, Sx2);
        int right = Math.Max(Sx1, Sx2);
        int top = Math.Max(Sy1, Sy2);
        int bottom = Math.Min(Sy1, Sy2);

        int damage = 0;

        if (Cx1 > left && Cx1 < right)
        {
            if (Cy1>bottom && Cy1<top)
            {
                damage += 100;
            }
            else if (Cy1 == bottom || Cy1 == top)
            {
                damage += 50;
            }
        }
        else if (Cx1 == left || Cx1 == right)
        {
            if (Cy1 > bottom && Cy1 < top)
            {
                damage += 50;
            }
            else if (Cy1 == top || Cy1 == bottom)
            {
                damage += 25;
            }
        }

        if (Cx2 > left && Cx2 < right)
        {
            if (Cy2 > bottom && Cy2 < top)
            {
                damage += 100;
            }
            else if (Cy2 == bottom || Cy2 == top)
            {
                damage += 50;
            }
        }
        else if (Cx2 == left || Cx2 == right)
        {
            if (Cy2 > bottom && Cy2 < top)
            {
                damage += 50;
            }
            else if (Cy2 == top || Cy2 == bottom)
            {
                damage += 25;
            }
        }

        if (Cx3 > left && Cx3 < right)
        {
            if (Cy3 > bottom && Cy3 < top)
            {
                damage += 100;
            }
            else if (Cy3 == bottom || Cy3 == top)
            {
                damage += 50;
            }
        }
        else if (Cx3 == left || Cx3 == right)
        {
            if (Cy3 > bottom && Cy3 < top)
            {
                damage += 50;
            }
            else if (Cy3 == top || Cy3 == bottom)
            {
                damage += 25;
            }
        }
        //if (Cx1 < left && Cx1 > right && Cy1 < top && Cy1 > bottom)
        //{
        //    damage += 100;
        //}
        //else if ((Cx1 == left || Cx1 == right) && Cy1 < top && Cy1 > bottom)
        //{
        //    damage += 50;
        //}
        //else if ((Cy1 == top || Cy1 == bottom) && Cx1 > left && Cx1 < right)
        //{
        //    damage += 50;
        //}
        //else if ((Cx1 == left || Cx1 == right) && (Cy1 == top || Cy1 == bottom))
        //{
        //    damage += 25;
        //}

        //if (Cx2 < left && Cx2 > right && Cy2 < top && Cy2 > bottom)
        //{
        //    damage += 100;
        //}
        //else if ((Cx2 == left || Cx2 == right) && Cy2 < top && Cy2 > bottom)
        //{
        //    damage += 50;
        //}
        //else if ((Cy2 == top || Cy2 == bottom) && Cx2 > left && Cx2 < right)
        //{
        //    damage += 50;
        //}
        //else if ((Cx2 == left || Cx2 == right) && (Cy2 == top || Cy2 == bottom))
        //{
        //    damage += 25;
        //}

        //if (Cx3 < left && Cx3 > right && Cy3 < top && Cy3 > bottom)
        //{
        //    damage += 100;
        //}
        //else if ((Cx3 == left || Cx3 == right) && Cy3 < top && Cy3 > bottom)
        //{
        //    damage += 50;
        //}
        //else if ((Cy3 == top || Cy3 == bottom) && Cx3 > left && Cx3 < right)
        //{
        //    damage += 50;
        //}
        //else if ((Cx3 == left || Cx3 == right) && (Cy3 == top || Cy3 == bottom))
        //{
        //    damage += 25;
        //}

        Console.WriteLine(damage + "%");
    }
}

