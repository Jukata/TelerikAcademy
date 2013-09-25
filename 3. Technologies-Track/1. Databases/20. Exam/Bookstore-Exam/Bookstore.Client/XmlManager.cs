using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bookstore.Client
{
    public class XmlManager
    {
        public static void ReadBooksAndAutors(string fileNameOrPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileNameOrPath);

            string xPath = @"/catalog/book";

            XmlNodeList booksList = doc.SelectNodes(xPath);

            foreach (XmlNode book in booksList)
            {
                string bookTitle = book.GetChildText("title");
                string isbn = book.GetChildText("isbn");
                string author = book.GetChildText("author");

                decimal? price = null;
                string priceStr = book.GetChildText("price");
                if (priceStr != null)
                {
                    price = decimal.Parse(priceStr);
                }

                string webSite = book.GetChildText("web-site");

                SqlManager.ImportBooksAndAuthors(bookTitle, isbn, author, price, webSite);
            }
        }

        public static void ReadBooksAuthorsAndReviews(string fileNameOrPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileNameOrPath);

            string xPath = @"/catalog/book";

            XmlNodeList bookList = doc.SelectNodes(xPath);

            foreach (XmlNode book in bookList)
            {
                string bookTitle = book.GetChildText("title");
                string isbn = book.GetChildText("isbn");

                decimal? price = null;
                string priceStr = book.GetChildText("price");
                if (priceStr != null)
                {
                    price = decimal.Parse(priceStr);
                }

                string webSite = book.GetChildText("web-site");

                List<string> authorsNames = GetAuthorsNames(book);
                List<ReviewData> reviewsData = GetReviewData(book);

                SqlManager.ImportBooksAuthorsAndReviews(bookTitle, isbn, price,
                    webSite, authorsNames, reviewsData);

            }
        }

        private static List<string> GetAuthorsNames(XmlNode book)
        {
            List<string> authorsNames = new List<string>();

            XmlNodeList authorsNodeList = book.SelectNodes(@"authors/author");
            foreach (XmlNode author in authorsNodeList)
            {
                string authorName = author.InnerText;
                authorsNames.Add(authorName);
            }

            return authorsNames;
        }

        private static List<ReviewData> GetReviewData(XmlNode book)
        {
            List<ReviewData> reviewsData = new List<ReviewData>();

            XmlNodeList reviewsNodeList = book.SelectNodes(@"reviews/review");

            foreach (XmlNode review in reviewsNodeList)
            {
                string content = review.InnerText.Trim();
                string authorName = review.GetAttributeText("author");
                string dateStr = review.GetAttributeText("date");

                DateTime date;
                if (dateStr == null)
                {
                    date = DateTime.Now;
                }
                else
                {
                    date = DateTime.Parse(dateStr, CultureInfo.InvariantCulture);
                }

                ReviewData reviewData = new ReviewData(authorName, date, content);
                reviewsData.Add(reviewData);
            }

            return reviewsData;
        }

        public static ICollection<Tuple<string, int>> SearchForBooks(string fileNameOrPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileNameOrPath);

            string xPath = @"/query";

            XmlNode query = doc.SelectSingleNode(xPath);

            string title = query.GetChildText("title");
            string author = query.GetChildText("author");
            string isbn = query.GetChildText("isbn");

            ICollection<Tuple<string, int>> result = SqlManager.SearchForBooks(title, author, isbn);

            return result;
        }

        public static void SearchForReviews(string inputFIle, string outputFIle)
        {
            DateTime searchDate = DateTime.Now;

            XmlDocument doc = new XmlDocument();
            doc.Load(inputFIle);

            string xPath = @"/review-queries/query";

            XmlNodeList queriesList = doc.SelectNodes(xPath);

            XmlWriter xmlWriter = XmlWriter.Create(outputFIle);

            using (xmlWriter)
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("search-results");

                foreach (XmlNode query in queriesList)
                {
                    //---For task 7.
                    SqlManager.SaveSearchLog(query.OuterXml, searchDate);
                    //---

                    xmlWriter.WriteStartElement("result-set");

                    string queryType = query.GetAttributeText("type");

                    if (queryType == "by-period")
                    {
                        DateTime startDate = DateTime.Parse(
                            query.GetChildText("start-date"), CultureInfo.InvariantCulture);
                        DateTime endDate = DateTime.Parse(
                               query.GetChildText("end-date"), CultureInfo.InvariantCulture);
                        SqlManager.SearchForReviews(xmlWriter, startDate, endDate);
                    }
                    else if (queryType == "by-author")
                    {
                        string authorName = query.GetChildText("author-name");
                        SqlManager.SearchForReviews(xmlWriter, authorName);
                    }

                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
        }

        internal static void WriteFoundReview(XmlWriter xmlWriter, DateTime date, string content,
            string bookTitle, string bookAuthors, string bookISBN, string bookUrl)
        {
            xmlWriter.WriteStartElement("review");

            if (date != null)
            {
                xmlWriter.WriteElementString("date", string.Format("{0:dd-MMM-yyyy}", date));
            }

            xmlWriter.WriteElementString("content", content);


            xmlWriter.WriteStartElement("book");

            if (bookTitle != null)
            {
                xmlWriter.WriteElementString("title", bookTitle);
            }
            if (!string.IsNullOrWhiteSpace(bookAuthors))
            {
                xmlWriter.WriteElementString("authors", bookAuthors);
            }
            if (bookISBN != null)
            {
                xmlWriter.WriteElementString("isbn", bookISBN);
            }
            if (bookUrl != null)
            {
                xmlWriter.WriteElementString("url", bookUrl);
            }

            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndElement();
        }
    }
}
