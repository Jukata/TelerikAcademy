//Write methods that calculate the surface of a triangle by given:
//Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

using System;

class TriangleSurface
{
    static void Main()
    {
        // released simple menu with simple data validation
        int choice;
        do
        {
            Console.Clear();
            Console.WriteLine("Choose method for calculate the area of triangle");
            Console.WriteLine("1. By side and altitude to it.");
            Console.WriteLine("2. By three sides.");
            Console.WriteLine("3. By two sides and angle between them.");
            Console.WriteLine("4. Exit.");
            do
            {
                Console.Write("Enter choice = ");
            } while (!(int.TryParse(Console.ReadLine(), out choice)) || choice < 1 || choice > 4);
            switch (choice)
            {
                case 1:
                    {
                        double side = 0.0d;
                        do
                        {
                            Console.Write("Enter side = ");
                        } while (!(double.TryParse(Console.ReadLine(), out side)) || side <= 0);
                        double altitude = 0.0d;
                        do
                        {
                            Console.Write("Enter altitude = ");
                        } while (!(double.TryParse(Console.ReadLine(), out altitude)) || altitude <= 0);
                        Console.WriteLine("The area of triangle is = {0}", CalculateSurface(side, altitude));
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                    }
                case 2:
                    {
                        double sideA = 0.0d;
                        double sideB = 0.0d;
                        double sideC = 0.0d;
                        do
                        {
                            do
                            {
                                Console.Write("Enter side A = ");
                            } while (!(double.TryParse(Console.ReadLine(), out sideA)) || sideA <= 0);
                            do
                            {
                                Console.Write("Enter side B = ");
                            } while (!(double.TryParse(Console.ReadLine(), out sideB)) || sideB <= 0);
                            do
                            {
                                Console.Write("Enter side C = ");
                            } while (!(double.TryParse(Console.ReadLine(), out sideC)) || sideC <= 0);
                        } while (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA);
                        Console.WriteLine("The area of triangle is = {0}", CalculateSurface(sideA, sideB, sideC));
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                    }
                case 3:
                    {
                        double sideA = 0.0d;
                        do
                        {
                            Console.Write("Enter side A = ");
                        } while (!(double.TryParse(Console.ReadLine(), out sideA)) || sideA <= 0);
                        double sideB = 0.0d;
                        do
                        {
                            Console.Write("Enter side B = ");
                        } while (!(double.TryParse(Console.ReadLine(), out sideB)) || sideB <= 0);
                        double angel = 0;
                        do
                        {
                            Console.Write("Enter angel in degrees = ");
                        } while (!(double.TryParse(Console.ReadLine(), out angel)) || angel <= 0 || angel >= 180);
                        Console.WriteLine("The area of triangle is = {0}", CalculateArea(sideA, sideB, angel));
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                    }
                case 4: Console.WriteLine("Bye!"); break;
                default: Console.WriteLine("Error!"); break;

            }
        } while (choice != 4);
    }

    static double CalculateSurface(double side, double altitude)
    {
        return (side * altitude) / 2;
    }
    static double CalculateSurface(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
    static double CalculateArea(double a, double b, double angle)
    {
        return (a * b * Math.Sin(Math.PI * angle / 180)) / 2; // Math.Sin angle argument is in radians
    }
}

