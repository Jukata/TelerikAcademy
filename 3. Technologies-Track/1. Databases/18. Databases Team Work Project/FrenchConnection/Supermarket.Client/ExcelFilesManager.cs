using SupermarketMSSql.Model;
using SupermarketSQLite.Model;
using System;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Supermarket.Client
{
    public static class ExcelFilesManager
    {
        public static void ReadExcelData(string rootDirPath)
        {
            DirectoryInfo rootDir = new DirectoryInfo(rootDirPath);
            foreach (var childDir in rootDir.GetDirectories())
            {
                string dirName = childDir.Name;
                DateTime reportDate = DateTime.ParseExact(dirName, "dd-MMM-yyyy", CultureInfo.InvariantCulture);

                foreach (var exFile in childDir.GetFiles())
                {
                    ReadData(exFile, rootDirPath, dirName, reportDate);
                }
            }
        }

        private static void ReadData(FileInfo exFile, string rootDirPath, string dirName, DateTime reportDate)
        {
            string fileName = exFile.Name;
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                      @" Data Source=" + rootDirPath + "\\" + dirName + "\\" + fileName + "; Persist Security Info=false; Extended Properties=Excel 8.0;";

            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();

            using (connection)
            {
                string sql = "SELECT * FROM [Sales$]";

                OleDbCommand cmd = new OleDbCommand(sql, connection);
                OleDbDataReader reader = cmd.ExecuteReader();

                int supermarketID = 0;
                int count = 0;
                while (reader.Read())
                {
                    if (count == 0)
                    {
                        supermarketID = MsSqlManager.InsertInSupermarketTable(reader[0].ToString());
                        count++;
                        continue;
                    }
                    else if (count == 1 || reader[0].ToString().Trim() == "…" || reader[0].ToString() == "Total sum:")
                    {
                        count++;
                        continue;
                    }
                    else
                    {
                        int productID = int.Parse(reader[0].ToString());
                        string mysqlProductName = MySqlManager.GetProductNameById(productID);
                        productID = MsSqlManager.GetProductIdByName(mysqlProductName);
                        int quantity = int.Parse(reader[1].ToString());
                        decimal unitPirce = decimal.Parse(reader[2].ToString());
                        decimal sum = decimal.Parse(reader[3].ToString());

                        MsSqlManager.InsertSalesReport(productID, quantity, unitPirce, sum, reportDate, supermarketID);
                    }
                }
            }
        }

        public static void WriteDataFromSQLite()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                        @" Data Source=../../vendors.xls; Persist Security Info=false; Extended Properties=Excel 8.0;";


            var conn1 = new OleDbConnection(connectionString);
            conn1.Open();
            using (conn1)
            {
                string sql = "CREATE TABLE [Product Reports] (Vendor string, Income decimal, Expenses decimal, Taxes decimal, [Financial Result] decimal)";
                var cmd = new OleDbCommand(sql, conn1);
                cmd.ExecuteNonQuery();
            }

            using (ProductReportsEntities sqLiteContext = new ProductReportsEntities())
            {
                using (SupermarketReportsEntities db = new SupermarketReportsEntities())
                {
                    DateTime currentDate = DateTime.Now;
                    var reports = db.SalesReports
                        .Where(d => d.ReportDate.Year == currentDate.Year && d.ReportDate.Month == currentDate.Month)
                        .GroupBy(v => v.Product.Vendors_VendorId).ToList();

                    foreach (var item in reports)
                    {
                        string vendorName = item.First().Product.Vendor.VendorName;
                        decimal income = sqLiteContext.ProductReports.Where(v => v.VendorName == vendorName).Sum(s => s.TotalIncomes);

                        int vendorID = item.First().Product.Vendor.VendorId;
                        var expencesList = db.Expenses
                            .Where(v => v.VendorId == vendorID && v.Date.Year == currentDate.Year && v.Date.Month == currentDate.Month)
                            .GroupBy(vi => vi.VendorId).FirstOrDefault();

                        if (expencesList == null)
                        {
                            continue;
                        }

                        decimal expences = expencesList.Sum(e => e.Expenses);

                        var taxes = sqLiteContext.Taxes;

                        decimal totalTaxes = 0;

                        foreach (var tax in taxes)
                        {
                            //string taxName = tax.Product_Name.Replace("”", "\"").Replace("“", "\"").Replace("’", "'");

                            var vId = sqLiteContext.ProductReports.Where(p => p.VendorName.Replace("”", "\"")
                                .Replace("“", "\"").Replace("’", "'") == vendorName).FirstOrDefault();
                            if (vId == null)
                            {
                                continue;
                            }

                            totalTaxes += vId.TotalIncomes;
                        }
                        var conn = new OleDbConnection(connectionString);
                        conn.Open();
                        using (conn)
                        {
                            string sql = "INSERT INTO [Product_Reports$](Vendor, Income, Expenses, Taxes, [Financial Result]) VALUES (@VendorName, @Income, @Expences, @Taxes, @FinancialResult)";
                            var cmd = new OleDbCommand(sql, conn);

                            cmd.Parameters.AddWithValue("@VendorName", vendorName);
                            cmd.Parameters.AddWithValue("@Income", income);
                            cmd.Parameters.AddWithValue("@Expences", expences);
                            cmd.Parameters.AddWithValue("@Taxes", totalTaxes);
                            cmd.Parameters.AddWithValue("@FinancialResult", income - expences - totalTaxes);

                            cmd.ExecuteNonQuery();
                        }

                        //var taxes = sqLiteContext.Taxes;

                        //foreach (var tax in taxes)
                        //{
                        //    string taxName = tax.Product_Name;

                        //    var vId = sqLiteContext.ProductReports.Where(p => p.ProductName.Replace("\\", "") == taxName).FirstOrDefault();
                        //    if (vId == null)
                        //    {
                        //        continue;
                        //    }
                        //    Console.WriteLine("{0} {1}", taxName);

                        //}
                    }
                }
            }
        }
    }
}
