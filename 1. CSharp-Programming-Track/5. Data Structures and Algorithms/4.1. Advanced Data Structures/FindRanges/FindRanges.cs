using System;
using System.Linq;
using Wintellect.PowerCollections;

class FindRanges
{
    private static Random randomGenerator = new Random();
    private static string chars = "ABCDEFGHIJKLMNOPQRSTIVWXYZabcdefghijklmnopqrstuvwxyz1234567890-=!@#$%^&*()_[]{}:";

    static void Main()
    {
        int productNameMaxLenghth = 30;
        double productMinPrice = 1;
        double productMaxPrice = 100;
        int count = 500000;
        int priceSearches = 10000;

        Console.WriteLine("Generating random products with random prices...");
        OrderedMultiDictionary<double, string> products = GenerateRandomProducts(
            count, productNameMaxLenghth, productMinPrice, productMaxPrice);

        DateTime startTime = DateTime.Now;
        Console.WriteLine("\nStart finding: {0}", DateTime.Now);
        for (int i = 0; i < priceSearches; i++)
        {
            double minRangePrice = GetRandomBetween(productMinPrice, productMaxPrice - 1);
            double maxRangePrice = GetRandomBetween(minRangePrice, productMaxPrice);
            var productsInRange = products.Range(minRangePrice, true, maxRangePrice, true).Take(20);
            // Warning!!! Printing is very slow operation.
            //Console.WriteLine("Produucts in range [{0}-{1}]: {2}", minRangePrice, maxRangePrice, string.Join("\n", productsInRange));
            //Console.WriteLine(new string('-',80));
        }
        Console.WriteLine("End finding: {0}", DateTime.Now);
        Console.WriteLine("Total finding time {0}", DateTime.Now - startTime);
    }

    private static OrderedMultiDictionary<double, string> GenerateRandomProducts(
        int count, int productNameMaxLenghth, double productMinPrice, double productMaxPrice)
    {
        OrderedMultiDictionary<double, string> result = new OrderedMultiDictionary<double, string>(true);

        for (int i = 0; i < count; i++)
        {
            string name = GenerateRandomProductName(productNameMaxLenghth);
            double price = GenerateRandomPrice(productMinPrice, productMaxPrice);
            result.Add(price, name);
        }

        return result;
    }

    private static double GenerateRandomPrice(double productMinPrice, double productMaxPrice)
    {
        double randomPrice = GetRandomBetween(productMinPrice, productMaxPrice);
        return randomPrice;
    }

    private static double GetRandomBetween(double productMinPrice, double productMaxPrice)
    {
        double randomPrice = productMinPrice + (randomGenerator.NextDouble() * (productMaxPrice - productMinPrice));
        return Math.Round(randomPrice, 2);
    }

    private static string GenerateRandomProductName(int productNameMaxLenghth)
    {
        if (productNameMaxLenghth < 0)
        {
            throw new ArgumentException("Product name length can't be negative");
        }

        char[] name = new char[productNameMaxLenghth];

        for (int i = 0; i < productNameMaxLenghth; i++)
        {
            name[i] = chars[randomGenerator.Next(chars.Length)];
        }

        return new string(name);
    }
}