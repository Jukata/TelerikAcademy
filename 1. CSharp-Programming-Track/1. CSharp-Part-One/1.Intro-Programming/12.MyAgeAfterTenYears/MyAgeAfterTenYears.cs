using System;

class MyAgeAfterTenYears
{

    static void Main()
    {
        byte currentAge;
        Console.Write("Ënter your current age: ");
        while (!(byte.TryParse(Console.ReadLine(), out currentAge)))
        {
            Console.Clear();
            Console.Write("Enter valid value for your age: ");
        }
        Console.WriteLine("Your age after 10 years will be {0}.", currentAge + 10);
        
        // If you want to use System.DateTime uncomment below.
        //DateTime myBirthdayYear = new DateTime();
        //Console.Write("Enter your current age: ");
        //byte currentAge = byte.Parse(Console.ReadLine());
        //myBirthdayYear = DateTime.Today.AddYears(-currentAge);
        //Console.WriteLine("Your age after 10 years will be {0}.",(DateTime.Today.Year - myBirthdayYear.Year)+10);
    }
}
