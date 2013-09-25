namespace Supermarket.Client
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Threading;
    using System.Globalization;
    using SupermarketSQLite.Model;
    using SupermarketMSSql.Model;
    using System.Data.OleDb;

    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            MsSqlManager.MigrateDataFromMySqlToMSSql();
            Console.WriteLine("Migrated database from mysql to sqlserver.");

            string zipPath = "../../Sample-Sales-Reports.zip";

            string destinationPath = "../../SalesReports";

            ZipManager.Unzip(zipPath, destinationPath);
            Console.WriteLine("Unziped archive...");

            ExcelFilesManager.ReadExcelData(destinationPath);
            Console.WriteLine("Excel data read.");

            //ZipManager.DeleteTempFiles(destinationPath);
            //Console.WriteLine("Deleted temp files");

            PdfManager.CreateSalesReportPdfFile("../../SalesReports/SalesReport.pdf");
            Console.WriteLine("Pdf created");

            XmlManager.PrintToXML();
            Console.WriteLine("Xml created");

            string mongoConnectionString = Settings.Default.MongoDbConnectionString;
            ProductReportsManager.CreateAndSaveProductReports(mongoConnectionString, "../../");
            Console.WriteLine("Products reports saved in mongo and mssql");

            string xmlExpenses = "../../expenses.xml";
            XmlManager.ReadXmlExpenses(xmlExpenses);

            var productReports = MongoDbManager.ReadProductsReport(mongoConnectionString, "SupermarketProductReports", "ProductsReports");

            SQLiteManager.InsertProductReports(productReports);
            Console.WriteLine("SQLite populated");

            ExcelFilesManager.WriteDataFromSQLite();
            Console.WriteLine("Excel file created");
        }
    }
}
