using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logs.Models
{
    public class SearchLogDbContext : DbContext
    {
        public SearchLogDbContext()
            : base("SearchLogsDb")
        {
        }

        public DbSet<SearchLog> SearchLogs { get; set; }
    }
}
