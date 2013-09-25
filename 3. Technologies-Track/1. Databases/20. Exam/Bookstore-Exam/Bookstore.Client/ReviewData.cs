using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Client
{
    public class ReviewData
    {
        public string AuthorName { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }

        public ReviewData(string authorName, DateTime date, string content)
        {
            this.AuthorName = authorName;
            this.Date = date;
            this.Content = content;
        }
    }
}
