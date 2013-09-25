using System;
using System.Collections.Generic;
using System.Linq;

class KnapsackProblem
{
    public class Product
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Cost { get; set; }

        public Product(string name, int weight, int cost)
        {
            this.Name = name;
            this.Weight = weight;
            this.Cost = cost;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Weight: {1}, Cost: {2}", this.Name, this.Weight, this.Cost);
        }
    }

    static void Main()
    {
        Product[] products = new Product[]{
            new Product("beer", 3, 2),
            new Product("vodka", 8, 12),  
            new Product("cheese", 4, 5),    
            new Product("nuts", 1, 4),
            new Product("ham", 2, 3),
            new Product("whiskey", 8, 13),
        };

        int capacity = 10;

        List<Product> takenProducts = SolveKnapsack(products, capacity);
        Console.WriteLine("Optimal solution:");
        Console.WriteLine(string.Join(" + ", takenProducts.Select(x => x.Name)));
        Console.WriteLine("Total weight = {0}", takenProducts.Sum(x => x.Weight));
        Console.WriteLine("Total cost = {0}", takenProducts.Sum(x => x.Cost));
    }

    public static List<Product> SolveKnapsack(Product[] products, int capacity)
    {
        if (products == null)
        {
            throw new ArgumentNullException("Products array can't be null.");
        }

        if (products.Length == 0)
        {
            return new List<Product>();
        }

        int[,] costs = new int[products.Length, capacity + 1];

        int[,] taken = new int[products.Length, capacity + 1];

        for (int i = 0; i <= products.Length - 1; i++)
        {
            costs[i, 0] = 0;
            taken[i, 0] = 0;
        }

        for (int j = 1; j <= capacity; j++)
        {
            if (products[0].Weight <= j)
            {
                costs[0, j] = products[0].Cost;
                taken[0, j] = 1;
            }
            else
            {
                costs[0, j] = 0;
                taken[0, j] = 0;
            }
        }

        for (int i = 0; i <= products.Length - 2; i++)
        {
            for (int j = 1; j <= capacity; j++)
            {
                var currentProduct = products[i + 1];

                if (currentProduct.Weight > j)
                {
                    costs[i + 1, j] = costs[i, j];
                }
                else
                {
                    int costWhenDropping = costs[i, j];
                    int costWhenTaking = costs[i, j - currentProduct.Weight] + currentProduct.Cost;

                    if (costWhenTaking > costWhenDropping)
                    {
                        costs[i + 1, j] = costWhenTaking;
                        taken[i + 1, j] = 1;
                    }
                    else
                    {
                        costs[i + 1, j] = costWhenDropping;
                        taken[i + 1, j] = 0;
                    }
                }
            }
        }

        List<Product> result = new List<Product>();

        {
            int remainingSpace = capacity;
            int product = products.Length - 1;

            while (product >= 0 && remainingSpace >= 0)
            {
                if (taken[product, remainingSpace] == 1)
                {
                    result.Add(products[product]);
                    remainingSpace -= products[product].Weight;
                    product -= 1;
                }
                else
                {
                    product -= 1;
                }
            }
        }

        return result;
    }
}