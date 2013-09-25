using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Client
{
    [DataContract]
    public class ProductReport
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public string VendorName { get; set; }

        [DataMember]
        public int TotalQuantitySold { get; set; }

        [DataMember]
        public decimal TotalIncomes { get; set; }

        public ProductReport(int productId, string productName, string vendorName, int totalQuantitySold, decimal totalIncomes)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.VendorName = vendorName;
            this.TotalQuantitySold = totalQuantitySold;
            this.TotalIncomes = totalIncomes;
        }
    }
}
