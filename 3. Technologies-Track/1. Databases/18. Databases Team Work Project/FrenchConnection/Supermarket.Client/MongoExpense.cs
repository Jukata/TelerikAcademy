using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Client
{
    public class MongoExpense
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public int VendorId { get; set; }
        public DateTime Date { get; set; }
        public decimal Expenses { get; set; }

        [BsonConstructor]
        public MongoExpense(int vendorId, DateTime date, decimal expenses)
        {
            this.VendorId = vendorId;
            this.Date = date;
            this.Expenses = expenses;
        }
    }
}
