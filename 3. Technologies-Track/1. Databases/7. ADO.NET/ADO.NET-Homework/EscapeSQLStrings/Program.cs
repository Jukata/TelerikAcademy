using System;
using System.Data.SqlClient;


class Program
{
    static void Main()
    {
        //8. Write a program that reads a string from the console and finds all products 
        //that contain this string. Ensure you handle correctly characters like ', %, ", \ and _.

        string connectioString = "Server=VIKTOR-PC;Database=Northwind;Integrated Security=true";
        SqlConnection connection = new SqlConnection(connectioString);

        connection.Open();

        Console.Write("Enter string fo search: ");
        string searchStr = Console.ReadLine().Replace("%", "[%]")
                                                .Replace("_", "[_]")
                                                .Replace("'", "[']")
                                                .Replace(@"\", @"[\]")
                                                .Replace("\"", "[\"]");

        using (connection)
        {
            SqlCommand command = new SqlCommand(
                @"SELECT ProductName 
                FROM Products
                WHERE ProductName LIKE @searchStr
                ORDER BY ProductName", connection);

            command.Parameters.AddWithValue("@searchStr", "%" + searchStr + "%");

            SqlDataReader dataReader = command.ExecuteReader();

            using (dataReader)
            {
                while (dataReader.Read())
                {
                    string productName = (string)dataReader["ProductName"];

                    Console.WriteLine("Product name: {0}", productName);
                }
            }
        }
    }
}