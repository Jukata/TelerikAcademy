using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Models;
using System.Xml;
using Logs.Models;

namespace Bookstore.Client
{
    public static class SqlManager
    {
        internal static void DeleteDataFromDb()
        {
            using (BookstoreEntities dbContext = new BookstoreEntities())
            {
                dbContext.Database.ExecuteSqlCommand(
                    @"DELETE FROM Books_Authors
                    DELETE FROM Reviews
                    DELETE FROM Authors
                    DELETE FROM Books");
            }
        }

        public static void ImportBooksAndAuthors(string bookTitle, string isbn,
            string author, decimal? price, string webSite)
        {
            using (BookstoreEntities dbContext = new BookstoreEntities())
            {
                Book newBook = new Book()
                {
                    Title = bookTitle.ToLower(),
                    ISBN = isbn,
                    Price = price,
                    website = webSite,
                };

                Author bookAutor = CreateOrLoadAuthor(dbContext, author);
                newBook.Authors.Add(bookAutor);

                dbContext.Books.Add(newBook);
                dbContext.SaveChanges();
            }
        }

        private static Author CreateOrLoadAuthor(BookstoreEntities dbContext, string authorName)
        {
            Author existingAuthor = dbContext.Authors.Where(a => a.Name == authorName.ToLower()).FirstOrDefault();

            if (existingAuthor != null)
            {
                return existingAuthor;
            }
            else
            {
                Author newAuthor = new Author() { Name = authorName.ToLower() };
                dbContext.Authors.Add(newAuthor);
                dbContext.SaveChanges();
                return newAuthor;
            }
        }

        public static void ImportBooksAuthorsAndReviews(string bookTitle, string isbn,
            decimal? price, string webSite, List<string> authorsNames, List<ReviewData> reviewsData)
        {
            using (BookstoreEntities dbContext = new BookstoreEntities())
            {
                Book newBook = new Book
                {
                    Title = bookTitle.ToLower(),
                    ISBN = isbn,
                    Price = price,
                    website = webSite,
                };

                foreach (string authorName in authorsNames)
                {
                    Author bookAutor = CreateOrLoadAuthor(dbContext, authorName);
                    newBook.Authors.Add(bookAutor);
                }

                foreach (ReviewData reviewData in reviewsData)
                {
                    Review newReview = new Review()
                    {
                        Content = reviewData.Content,
                        CreationDate = reviewData.Date,
                    };

                    if (reviewData.AuthorName != null)
                    {
                        newReview.Author = CreateOrLoadAuthor(dbContext, reviewData.AuthorName);
                    }

                    newBook.Reviews.Add(newReview);
                }

                dbContext.Books.Add(newBook);
                dbContext.SaveChanges();
            }
        }

        public static ICollection<Tuple<string, int>> SearchForBooks(string title, string author, string isbn)
        {

            if (title != null || author != null || isbn != null)
            {
                IQueryable<Book> queryResult;

                using (BookstoreEntities dbContext = new BookstoreEntities())
                {
                    queryResult = dbContext.Books;

                    if (title != null)
                    {
                        queryResult = queryResult.Where(b => b.Title == title.ToLower());
                    }
                    if (author != null)
                    {
                        queryResult = queryResult.Where(b => b.Authors.Any(a => a.Name == author.ToLower()));
                    }
                    if (isbn != null)
                    {
                        queryResult = queryResult.Where(b => b.ISBN == isbn);
                    }

                    queryResult.OrderBy(b => b.Title);


                    ICollection<Tuple<string, int>> result = new List<Tuple<string, int>>();

                    foreach (Book book in queryResult)
                    {
                        result.Add(new Tuple<string, int>(book.Title, book.Reviews.Count));
                    }

                    return result;
                }
            }
            else
            {
                return new List<Tuple<string, int>>();
            }
        }

        public static void SearchForReviews(XmlWriter xmlWriter, DateTime startDate, DateTime endDate)
        {
            using (BookstoreEntities dbContext = new BookstoreEntities())
            {
                var reviewsFound = dbContext.Reviews.Include("Book").Include("Author")
                    .Where(r => r.CreationDate >= startDate && r.CreationDate <= endDate)
                    .OrderBy(r => r.CreationDate).ToList().OrderBy(r => r.Content);

                foreach (Review review in reviewsFound)
                {

                    List<string> authors = review.Book.Authors.Select(a => a.Name).ToList();
                    authors.Sort();

                    string authorsStr = string.Join(", ", authors);

                    XmlManager.WriteFoundReview(xmlWriter, review.CreationDate, review.Content, review.Book.Title,
                        authorsStr, review.Book.ISBN, review.Book.website);
                }
            }
        }

        public static void SearchForReviews(XmlWriter xmlWriter, string authorName)
        {
            using (BookstoreEntities dbContext = new BookstoreEntities())
            {
                var reviewsFound = dbContext.Reviews.Include("Book").Include("Author")
                    .Where(r => r.Author.Name == authorName.ToLower())
                    .OrderBy(r => r.CreationDate).ToList().OrderBy(r => r.Content);

                foreach (Review review in reviewsFound)
                {
                    List<string> authors = review.Book.Authors.Select(a => a.Name).ToList();
                    authors.Sort();

                    string authorsStr = string.Join(", ", authors);

                    XmlManager.WriteFoundReview(xmlWriter, review.CreationDate, review.Content, review.Book.Title,
                    authorsStr, review.Book.ISBN, review.Book.website);
                }
            }
        }


        //--- task 7.
        public static void SaveSearchLog(string queryXml, DateTime searchDate)
        {
            using (SearchLogDbContext dbContext = new SearchLogDbContext())
            {
                SearchLog log = new SearchLog()
                {
                    QueryXml = queryXml,
                    SearchDate = searchDate,
                };

                dbContext.SearchLogs.Add(log);

                dbContext.SaveChanges();
            }
        }
    }
}
