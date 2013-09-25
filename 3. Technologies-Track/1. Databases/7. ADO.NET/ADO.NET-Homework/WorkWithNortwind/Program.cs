using System;
using System.Data.SqlClient;
using System.IO;
using WorkWithNortwind;

class Program
{
    private static string separator = new string('-', 60);

    static void Main()
    {
        FindCategoriesCount(); // 1.
        ReadNameAndDescriptionPfAllCategories(); // 2.
        ReadAllProductCategoriesAndProductNames(); //3.
        InsertProduct("Zaio Baio", 2, 3, "200g pkgs.", 0.35m, 100, 50, 15, false); //4.
        ReadImagesForAllCategories(); //5.
    }

    private static void FindCategoriesCount()
    {
        //1. Write a program that retrieves from the Northwind sample database in 
        //MS SQL Server the number of  rows in the Categories table.
        string connectionString = Settings.Default.DbConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        using (connection)
        {
            SqlCommand command = new SqlCommand("SELECT Count(*) FROM Categories", connection);
            int categoriesCount = (int)command.ExecuteScalar();

            Console.WriteLine("Number of rows in the 'Categories' table => {0}.", categoriesCount);
        }
    }

    private static void ReadNameAndDescriptionPfAllCategories()
    {
        //2. Write a program that retrieves the name and description of all categories in the Northwind DB.
        Console.WriteLine(separator);

        string connectionString = Settings.Default.DbConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        using (connection)
        {
            SqlCommand command = new SqlCommand("SELECT CategoryName, Description FROM Categories", connection);

            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                string name = (string)dataReader["CategoryName"];
                string description = (string)dataReader["Description"];

                Console.WriteLine("CategoryName = {0}, Description = {1}", name, description);
            }
        }
    }

    private static void ReadAllProductCategoriesAndProductNames()
    {
        //3. Write a program that retrieves from the Northwind database 
        //all product categories and the names of the products in each category. 
        //Can you do this with a single SQL query (with table join)?
        Console.WriteLine(separator);

        string connectionString = Settings.Default.DbConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        using (connection)
        {
            SqlCommand command = new SqlCommand(@"
                SELECT c.CategoryName, p.ProductName 
                FROM Categories AS c JOIN Products AS p
                ON c.CategoryID = p.CategoryID 
                ORDER BY c.CategoryName", connection);

            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                string categoryName = (string)dataReader["CategoryName"];
                string productName = (string)dataReader["ProductName"];

                Console.WriteLine("Category Name {0} - Product Name {1}.", categoryName, productName);
            }
        }
    }

    private static void InsertProduct(string productName, int supplierId, int categoryId, string quantityPerUnit,
        decimal unitPrice, short unitsInStock, short unitsOnOrder, short reorderLevel, bool discontinued)
    {
        //4. Write a method that adds a new product in the products table 
        //in the Northwind database. Use a parameterized SQL command.

        Console.WriteLine(separator);

        string connectionString = Settings.Default.DbConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        using (connection)
        {
            SqlCommand command = new SqlCommand(@"
                INSERT INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, 
                    UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
                VALUES(@productName, @SupplierId, @CategoryId, @quantityPerUnit,
                    @unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued);", connection);

            command.Parameters.AddWithValue("@productName", productName);
            command.Parameters.AddWithValue("@supplierId", supplierId);
            command.Parameters.AddWithValue("@categoryId", categoryId);
            command.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
            command.Parameters.AddWithValue("@unitPrice", unitPrice);
            command.Parameters.AddWithValue("@unitsInStock", unitsInStock);
            command.Parameters.AddWithValue("@unitsOnOrder", unitsOnOrder);
            command.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            command.Parameters.AddWithValue("@discontinued", discontinued);

            int affectedCount = command.ExecuteNonQuery();

            if (affectedCount == 1)
            {
                Console.WriteLine("Added succesfull. ");
            }
        }
    }

    private static void ReadImagesForAllCategories()
    {
        //5. Write a program that retrieves the images for all categories in the 
        //Northwind database and stores them as JPG files in the file system.

        Console.WriteLine(separator);

        string connectionString = Settings.Default.DbConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        using (connection)
        {
            SqlCommand command = new SqlCommand("SELECT CategoryName, Picture FROM Categories", connection);

            SqlDataReader dataReader = command.ExecuteReader();
            dataReader.Read();

            while (dataReader.Read())
            {
                string categoryName = (string)dataReader["CategoryName"];
                byte[] imageBytes = (byte[])dataReader["Picture"];
                WriteBinaryFile(categoryName, imageBytes, ".jpg");
            }
        }
    }

    private static void WriteBinaryFile(string fileName, byte[] fileContents, string extension)
    {
        FileStream stream = File.OpenWrite(fileName.Replace("\\", " ").Replace("/", " ") + extension);
        using (stream)
        {
            stream.Write(fileContents, 76, fileContents.Length - 76);
        }
    }
}
