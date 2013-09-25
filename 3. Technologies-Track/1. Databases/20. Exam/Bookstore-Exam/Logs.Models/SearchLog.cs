using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logs.Models
{
    public class SearchLog
    {
        [Key]
        public int SearchLogId { get; set; }

        [Required]
        public DateTime SearchDate { get; set; }

        [Required]
        public string QueryXml { get; set; }
    }
}
