using SupermarketSQLite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Client
{
    public static class SQLiteManager
    {
        public static void InsertProductReports(ICollection<ProductReport> productReports)
        {
            using (ProductReportsEntities sqLiteContext = new ProductReportsEntities())
            {
                foreach (var productReport in productReports)
                {
                    SupermarketSQLite.Model.ProductReport report = new SupermarketSQLite.Model.ProductReport()
                    {
                        ProductId = productReport.ProductId,
                        ProductName = productReport.ProductName,
                        TotalIncomes = productReport.TotalIncomes,
                        TotalQuantitySold = productReport.TotalQuantitySold,
                        VendorName = productReport.VendorName
                    };

                    sqLiteContext.ProductReports.Add(report);
                }
                sqLiteContext.SaveChanges();
            }
        }
    }
}
