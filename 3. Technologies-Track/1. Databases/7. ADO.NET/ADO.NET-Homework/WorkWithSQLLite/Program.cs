using System;
using System.Data.SQLite;

class Program
{
    static void Main()
    {
        //10. Re-implement the previous task with SQLite embedded DB (see http://sqlite.phxsoftware.com).

        ListAllBooks("C# Programming");

        AddNewBook(15, "C++ Programming", DateTime.Now, "987645", 5);
        AddNewBook(16, "C Programming", null, "187645", 5);
    }

    private static void AddNewBook(int id, string title, DateTime? publishDate, string ISBN, int authorId)
    {
        string connectionString = "Data Source=../../BooksStore.db;Version=3;";

        SQLiteConnection connection = new SQLiteConnection(connectionString);

        connection.Open();

        using (connection)
        {
            SQLiteCommand command = new SQLiteCommand(
                @"INSERT INTO Books (BookId, title, publishDate, ISBN, AuthorId)
                VALUES(@id, @title, @publishDate, @ISBN, @AuthorId)", connection);

            command.Parameters.AddWithValue("@id", id);
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
        string connectionString = "Data Source=../../BooksStore.db;Version=3;";

        SQLiteConnection connection = new SQLiteConnection(connectionString);

        connection.Open();

        using (connection)
        {
            SQLiteCommand command = new SQLiteCommand(
                @"SELECT b.Title, PublishDate, ISBN, a.FirstName, a.LastName
                FROM Books AS b JOIN Authors AS a ON b.AuthorId = a.AuthorId
                WHERE b.Title = @bookTitle", connection);

            command.Parameters.AddWithValue("@bookTitle", titleToSearch);

            SQLiteDataReader dataReader = command.ExecuteReader();

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
