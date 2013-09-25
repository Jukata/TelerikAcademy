using MongoDB.Driver;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;


namespace Supermarket.Client
{
    public static class ProductReportsManager
    {
        private const string DatabaseName = "SupermarketProductReports";
        private const string CollectionName = "ProductsReports";
        private const string ReportsFolderName = "Product-Reports";

        public static void CreateAndSaveProductReports(string mongoConnectionString, string jsonFilePath)
        {
            using (var context = new SupermarketMSSql.Model.SupermarketReportsEntities())
            {
                var allProductsIds = context.Products.Select(x => x.Productid);

                foreach (var id in allProductsIds)
                {
                    ProductReport report = ProductReportsManager.GenerateProductReport(id);
                    ProductReportsManager.SaveToFileSystemAsJson(report, jsonFilePath);
                    MongoDbManager.SaveToMongoDB(report, mongoConnectionString, DatabaseName, CollectionName);
                }
            }
        }

        public static ProductReport GenerateProductReport(int productId)
        {
            using (var db = new SupermarketMSSql.Model.SupermarketReportsEntities())
            {
                var product = db.Products.Include("Vendor").Where(p => p.Productid == productId).FirstOrDefault();

                int totalQuantitySold = 0;
                decimal totalIncomes = 0M;

                try
                {
                    totalQuantitySold = db.SalesReports.Where(x => x.ProductId == productId).Sum(x => x.Quantity);
                    totalIncomes = db.SalesReports.Where(x => x.ProductId == productId).Sum(x => x.Sum);
                }
                catch (InvalidOperationException)
                {
                    totalQuantitySold = 0;
                    totalIncomes = 0M;
                }

                ProductReport report = new ProductReport(product.Productid, product.ProductName,
                    product.Vendor.VendorName, totalQuantitySold, totalIncomes);

                return report;
            }
        }

        private static void SaveToFileSystemAsJson(ProductReport report, string path)
        {
            string fullPath = path + "/" + ReportsFolderName;

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            string fileName = report.ProductId + ".json";

            fullPath = fullPath + "/" + fileName;

            FileStream stream = new FileStream(fullPath, FileMode.Create);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ProductReport));

            using (stream)
            {
                serializer.WriteObject(stream, report);
                stream.Flush();
            }
        }
    }
}
