namespace Supermarket.Client
{
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using SupermarketMSSql.Model;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    public static class PdfManager
    {
        public static void CreateSalesReportPdfFile(string location)
        {
            using (SupermarketReportsEntities msSqlDb = new SupermarketReportsEntities())
            {
                ICollection<SupermarketMSSql.Model.SalesReport> result = msSqlDb.SalesReports.Include("Product").Include("Supermarket").ToList();

                FillPdfReportFile(result, location);
            }
        }

        public static void FillPdfReportFile(ICollection<SupermarketMSSql.Model.SalesReport> result, string location)
        {
            Document document = new Document(PageSize.A4, 80, 50, 30, 65);
            PdfWriter.GetInstance(document, new FileStream(location, FileMode.Create));

            document.Open();

            PdfPTable table = new PdfPTable(5);

            PdfPCell header = new PdfPCell(new Phrase("Aggregated Sales Report"));
            header.BackgroundColor = new BaseColor(149, 149, 149);
            header.Colspan = 5;
            header.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            table.AddCell(header);

            var groupedByDate = result.GroupBy(x => x.ReportDate).ToList();

            foreach (var grouped in groupedByDate)
            {
                PdfPCell dateBelowHeader = new PdfPCell(new Phrase("Date: " + grouped.First()
                                                                                     .ReportDate
                                                                                     .ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture)));
                dateBelowHeader.Colspan = 5;
                dateBelowHeader.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                dateBelowHeader.BackgroundColor = new BaseColor(187, 187, 187);
                table.AddCell(dateBelowHeader);

                table.AddCell("Product");
                table.AddCell("Quantity");
                table.AddCell("Unit Price");
                table.AddCell("Location");
                table.AddCell("Sum");
                foreach (var item in grouped)
                {
                    table.AddCell(item.Product.ProductName.ToString());
                    table.AddCell(item.Quantity.ToString());
                    table.AddCell(item.UnitPrice.ToString());
                    table.AddCell(item.Supermarket.Name);
                    table.AddCell(item.Sum.ToString());
                }
            }

            document.Add(table);
            document.Close();
        }
    }
}
