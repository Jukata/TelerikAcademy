namespace Supermarket.Client
{
    using SupermarketMSSql.Model;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    public static class XmlManager
    {
        public static void PrintToXML()
        {
            using (SupermarketReportsEntities msSqlDb = new SupermarketReportsEntities())
            {
                var doc = new XDocument();
                var sales = new XElement("sales");

                var salesReports = msSqlDb.SalesReports
                                          .Include("Product")
                                          .Include("Supermarket")
                                          .Include("Vendor")
                                          .GroupBy(x => x.Product.Vendor.VendorName)
                                          .ToList();

                foreach (var report in salesReports)
                {
                    var sale = new XElement("sale", new XAttribute("vendor", report.First().Product.Vendor.VendorName));

                    foreach (var item in report)
                    {
                        sale.Add(new XElement("summary",
                                            new XAttribute("date", item.ReportDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture)),
                                            new XAttribute("total-sum", item.Sum)));
                    }
                    sales.Add(sale);
                }

                doc.Add(sales);

                doc.Save("../../SalesReports/Sales-by-Vendors-report.xml");
            }
        }

        public static void ReadXmlExpenses(string pathToFile)
        {
            XmlTextReader reader = new XmlTextReader(pathToFile);

            string vendorName = string.Empty;
            DateTime date = new DateTime();
            decimal expenses = 0;

            using (reader)
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {
                            reader.MoveToNextAttribute();
                            if (reader.Name == "vendor")
                            {
                                vendorName = reader.Value;
                            }
                            else if (reader.Name == "month")
                            {
                                date = DateTime.Parse(reader.Value);
                            }
                        }

                        reader.MoveToElement();
                    }

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "expenses")
                    {
                        var expenseStr = reader.ReadInnerXml();
                        expenses = decimal.Parse(expenseStr);

                        int vendorId = MsSqlManager.InsertExpenses(vendorName, date, expenses);

                        MongoExpense mongoExpense = new MongoExpense(vendorId, date, expenses);

                        MongoDbManager.IsertExpenses(mongoExpense, "mongodb://localhost",
                            "SupermarketProductReports", "Expenses");
                    }
                }
            }
        }
    }
}
