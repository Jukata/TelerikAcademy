namespace Supermarket.Client
{
    using SupermarketMSSql.Model;
    using SupermarketMySql.Model;
    using System;
    using System.Linq;

    public static class MsSqlManager
    {
        public static void MigrateDataFromMySqlToMSSql()
        {
            using (SupermarketMySqlEntities mySqlDb = new SupermarketMySqlEntities())
            {
                using (SupermarketReportsEntities msSqlDb = new SupermarketReportsEntities())
                {
                    var vendors = mySqlDb.Vendors;
                    foreach (var vendor in vendors)
                    {
                        SupermarketMSSql.Model.Vendor newVendor = new SupermarketMSSql.Model.Vendor
                        {
                            VendorName = vendor.VendorName
                        };

                        msSqlDb.Vendors.Add(newVendor);
                    }

                    msSqlDb.SaveChanges();
                    var measures = mySqlDb.Measures;
                    foreach (var measure in measures)
                    {
                        SupermarketMSSql.Model.Measure newMeasure = new SupermarketMSSql.Model.Measure
                        {
                            MeasureName = measure.MeasureName
                        };

                        msSqlDb.Measures.Add(newMeasure);
                    }

                    msSqlDb.SaveChanges();

                    var products = mySqlDb.Products;
                    foreach (var product in products)
                    {
                        var vendor = msSqlDb.Vendors.Where(v => v.VendorName == product.Vendor.VendorName).First();
                        var measure = msSqlDb.Measures.Where(m => m.MeasureName == product.Measure.MeasureName).First();
                        SupermarketMSSql.Model.Product newProduct = new SupermarketMSSql.Model.Product
                        {
                            ProductName = product.ProductName,
                            BasePrice = product.BasePrice,
                            Measures_MeasureId = measure.MeasureId,
                            Vendors_VendorId = vendor.VendorId
                        };

                        msSqlDb.Products.Add(newProduct);
                    }

                    msSqlDb.SaveChanges();
                }
            }
        }

        public static int InsertInSupermarketTable(string supermarketName)
        {
            SupermarketReportsEntities db = new SupermarketReportsEntities();
            using (db)
            {
                var supermarket = new SupermarketMSSql.Model.Supermarket()
                {
                    Name = supermarketName
                };

                bool doesExist = db.Supermarkets.Any(s => s.Name == supermarket.Name);

                //bool doesExist = db.Supermarkets.Select(s => s.Name == supermarket.Name).ToList().Count > 0;
                if (!doesExist)
                {
                    db.Supermarkets.Add(supermarket);
                    db.SaveChanges();
                }

                return db.Supermarkets
                    .Where(s => s.Name == supermarket.Name)
                    .First()
                    .SupermarketId;
            }
        }

        public static void InsertSalesReport(int productID, int quantity, decimal unitPrice,
            decimal sum, DateTime reportDate, int supermarketID)
        {
            SupermarketReportsEntities db = new SupermarketReportsEntities();
            using (db)
            {
                SalesReport report = new SalesReport()
                {
                    ProductId = productID,
                    Quantity = quantity,
                    ReportDate = reportDate,
                    SupermarketId = supermarketID,
                    UnitPrice = unitPrice,
                    Sum = sum
                };

                db.SalesReports.Add(report);
                db.SaveChanges();
            }
        }

        public static int GetProductIdByName(string mysqlProductName)
        {
            SupermarketReportsEntities db = new SupermarketReportsEntities();
            using (db)
            {
                var product = db.Products.Where(p => p.ProductName == mysqlProductName).First();
                return product.Productid;
            }
        }

        public static int InsertExpenses(string vendorName, DateTime date, decimal expenses)
        {
            int vendorID;
            SupermarketReportsEntities db = new SupermarketReportsEntities();

            using (db)
            {
                vendorID = db.Vendors
                    .Where(v => v.VendorName == vendorName)
                    .First()
                    .VendorId;

                Expens newExpense = new Expens
                {
                    VendorId = vendorID,
                    Date = date,
                    Expenses = expenses
                };

                db.Expenses.Add(newExpense);
                db.SaveChanges();
            }

            return vendorID;
        }
    }
}
