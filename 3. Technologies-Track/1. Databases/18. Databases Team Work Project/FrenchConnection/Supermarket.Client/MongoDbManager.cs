using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Client
{
    public static class MongoDbManager
    {
        public static void SaveToMongoDB(ProductReport report, string connectionString,
            string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase(databaseName);
            var collection = database.GetCollection(collectionName);

            collection.Insert(report);
        }

        public static void IsertExpenses(MongoExpense mongoExpense, string connectionString,
            string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase(databaseName);
            var collection = database.GetCollection(collectionName);

            collection.Insert(mongoExpense);
        }

        public static ICollection<ProductReport> ReadProductsReport(string connectionString,
            string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase(databaseName);
            var collection = database.GetCollection(collectionName);

            var productReports = new List<ProductReport>();

            foreach (var productReport in collection.FindAllAs<ProductReport>())
            {
                productReports.Add(productReport);
            }

            return productReports;
        }
    }
}
