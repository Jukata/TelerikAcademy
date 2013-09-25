using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bookstore.Client
{
    public class Program
    {
        static void Main()
        {
            SqlManager.DeleteDataFromDb();

            //task 3. 
            XmlManager.ReadBooksAndAutors("../../simple-books.xml");

            //task 4.
            XmlManager.ReadBooksAuthorsAndReviews("../../complex-books.xml");

            //task 5.
            ICollection<Tuple<string, int>> searchResult = XmlManager.SearchForBooks("../../simple-query.xml");
            PrintSearchResultToConsole(searchResult);

            //ICollection<Tuple<string, int>> searchResult2 = XmlManager.SearchForBooks("../../simple-query2.xml");
            //PrintSearchResultToConsole(searchResult2);

            ICollection<Tuple<string, int>> searchResult3 = XmlManager.SearchForBooks("../../simple-query3.xml");
            PrintSearchResultToConsole(searchResult3);

            //task 6. and task 7. Inside method
            XmlManager.SearchForReviews("../../reviews-queries.xml", "../../reviews-search-results.xml");

        }

        private static void PrintSearchResultToConsole(ICollection<Tuple<string, int>> searchResult)
        {
            if (searchResult.Count > 0)
            {
                Console.WriteLine("{0} books found:", searchResult.Count);

                foreach (var item in searchResult)
                {
                    int reviewsCount = item.Item2;
                    Console.WriteLine("{0} --> {1} reviews", item.Item1, reviewsCount == 0 ? "no" : reviewsCount.ToString());
                }
            }
            else
            {
                Console.WriteLine("Nothing found");
            }
        }
    }
}
