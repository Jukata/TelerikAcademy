using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        //9. MySQL Workbench GUI administration tool . Create a MySQL database to
        //store Books (title, author, publish date and ISBN). Write methods for
        //listing all books, finding a book by name and adding a book

        ListAllBooks("C# Programming");

        AddNewBook("C++ Programming", DateTime.Now, "987645", 5);
        AddNewBook("C Programming", null, "187645", 5);
    }

    private static void AddNewBook(string title, DateTime? publishDate, string ISBN, int authorId)
    {
        string connectionString = "SERVER=localhost;DATABASE=bookstore;UID=user;PASSWORD=pass;";

        MySqlConnection connection = new MySqlConnection(connectionString);

        connection.Open();

        using (connection)
        {
            MySqlCommand command = new MySqlCommand(
                @"INSERT INTO Books (title, publishDate, ISBN, AuthorId)
                VALUES(@title, @publishDate, @ISBN, @AuthorId)", connection);

            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@ISBN", ISBN);
            command.Parameters.AddWithValue("@AuthorId", authorId);
            command.Parameters.AddWithValue("@publishDate", publishDate);

            int affectedRows = command.ExecuteNonQuery();
            if (affectedRows == 1)
            {
                Console.WriteLine("Added succesfull");
            }
        }
    }

    private static void ListAllBooks(string titleToSearch)
    {
        string connectionString = "SERVER=localhost;DATABASE=bookstore;UID=user;PASSWORD=pass;";

        MySqlConnection connection = new MySqlConnection(connectionString);

        connection.Open();

        using (connection)
        {
            MySqlCommand command = new MySqlCommand(
                @"SELECT b.Title, PublishDate, ISBN, a.FirstName, a.LastName
                FROM Books AS b JOIN Authors AS a ON b.AuthorId = a.AuthorId
                WHERE b.Title = @bookTitle", connection);

            command.Parameters.AddWithValue("@bookTitle", titleToSearch);

            MySqlDataReader dataReader = command.ExecuteReader();

            using (dataReader)
            {
                while (dataReader.Read())
                {
                    string bookTitle = (string)dataReader["Title"];
                    string ISBN = (string)dataReader["ISBN"];
                    string authorName = (string)dataReader["FirstName"] + (string)dataReader["LastName"];

                    DateTime? publishDate;
                    object dt = dataReader["PublishDate"];
                    if (dt == DBNull.Value)
                    {
                        publishDate = null;
                    }
                    else
                    {
                        publishDate = (DateTime)dt;
                    }

                    Console.WriteLine("Book name - " + bookTitle);
                    Console.WriteLine("Book ISBN - " + ISBN);
                    Console.WriteLine("Author name - " + authorName);

                    if (publishDate != null)
                    {
                        Console.WriteLine("Publish Date - " + publishDate);
                    }
                }
            }
        }
    }
}
