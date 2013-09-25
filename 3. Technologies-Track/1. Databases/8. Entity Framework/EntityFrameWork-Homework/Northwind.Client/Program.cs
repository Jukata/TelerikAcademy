using Northwind.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Client
{
    public class Program
    {
        static void Main()
        {
            //2. 
            //try
            //{
            //    CustomerDAO.Insert("AABBB", "Telerik1");

            //    CustomerDAO.Modify("AABBB", "Telerik");

            //    CustomerDAO.Delete("AABBB");
            //}
            //catch (InvalidOperationException ioe)
            //{
            //    Console.WriteLine(ioe.InnerException.Message);
            //}

            //3. 
            //var queryResult = FindAllCustomersInCanadaWithOrdersIn1997();

            //foreach (var name in queryResult)
            //{
            //    Console.WriteLine(name);
            //}
            //Console.WriteLine(new string('-', 40));

            //4.
            //queryResult = FindAllCustomersInCanadaWithOrdersIn1997Native();

            //foreach (var name in queryResult)
            //{
            //    Console.WriteLine(name);
            //}
            //Console.WriteLine(new string('-', 40));

            //5. 
            //var sales = FindAllSalesIn("RJ", new DateTime(1997, 6, 15), DateTime.Now);
            //foreach (var sale in sales)
            //{
            //    Console.WriteLine(sale);
            //}
            //Console.WriteLine(new string('-', 40));

            //6. 
            //CreateNorthwindTwin();

            //7.
            //MakeConcurencyChanges();

            //9.
            //for (int i = 100; i < 123; i++)
            //{
            //    PlaceNewOrder(i);
            //}

            //10.
            //decimal? totalIncome = GetIncome("Exotic Liquids", new DateTime(1975, 5, 1), DateTime.Now);//new DateTime(1995, 9, 1));
        }

        public static IEnumerable<string> FindAllCustomersInCanadaWithOrdersIn1997()
        {
            //3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.

            using (NorthwindEntities dbContext = new NorthwindEntities())
            {

                var customers = dbContext.Orders
                    .Where(o => o.OrderDate.Value.Year == 1997)
                    .Where(o => o.ShipCountry == "Canada")
                    .Join(dbContext.Customers, (o => o.CustomerID), (c => c.CustomerID),
                     (o, c) => c.ContactName);

                return customers.ToList();
            }
        }

        public static IEnumerable<string> FindAllCustomersInCanadaWithOrdersIn1997Native()
        {
            //4. Implement previous by using native SQL query and executing it through the DbContext.

            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                var customers = dbContext.Database.SqlQuery<string>(
                        @"SELECT c.ContactName
                        FROM Customers AS c JOIN Orders AS o ON c.CustomerID = o.CustomerID
                        WHERE YEAR(o.OrderDate) = 1997 AND o.ShipCountry ='Canada'");

                return customers.ToList();
            }
        }

        public static IEnumerable<object> FindAllSalesIn(string region, DateTime startDate, DateTime endDate)
        {
            //5. Write a method that finds all the sales by specified region and period (start / end dates).

            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                var orders = dbContext.Orders
                    .Where(o => o.ShippedDate > startDate)
                    .Where(o => o.ShippedDate < endDate)
                    .Where(o => o.ShipRegion.ToLower() == region.ToLower())
                    .Select(o => new { o.ShippedDate, o.ShipName, o.ShipRegion }).ToList();

                return orders.ToList();
            }
        }

        public static void CreateNorthwindTwin()
        {
            //6. Create a database called NorthwindTwin with the same structure as Northwind
            //using the features from DbContext. Find for the API for schema generation in MSDN or in Google.

            IObjectContextAdapter dbContextAdapter = new NorthwindEntities();


            string dbScript =
                "DROP DATABASE IF EXISTS NorthwindTwin" +
                "CREATE DATABASE NorthwindTwin ON PRIMARY " +
                "(NAME = NorthwindTwin, " +
                "FILENAME = 'C:\\NorthwindTwin.mdf', " +
                "SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                "LOG ON (NAME = NorthwindTwinLog, " +
                "FILENAME = 'C:\\NorthwindTwin.ldf', " +
                "SIZE = 1MB, " +
                "MAXSIZE = 5MB, " +
                "FILEGROWTH = 10%)" +
                dbContextAdapter.ObjectContext.CreateDatabaseScript().Replace("Northwind", "NorthwindTwin");

            string connectionString = "Server=LOCALHOST;Database=master;Integrated Security=true";
            SqlConnection dbConForCreatingDB = new SqlConnection(connectionString);

            dbConForCreatingDB.Open();

            using (dbConForCreatingDB)
            {
                SqlCommand createDB = new SqlCommand(dbScript, dbConForCreatingDB);
                createDB.ExecuteNonQuery();
            }
        }

        private static void MakeConcurencyChanges()
        {
            //7. Try to open two different data contexts and perform concurrent changes 
            //on the same records. What will happen at SaveChanges()? How to deal with it?

            NorthwindEntities dbContext1 = new NorthwindEntities();
            Employee employee1 = dbContext1.Employees.Find(10);
            //employee1.City = "Burgas";
            dbContext1.Employees.Remove(employee1);

            //dbContext1.SaveChanges();

            NorthwindEntities dbContext2 = new NorthwindEntities();
            Employee employee2 = dbContext2.Employees.Find(10);
            employee2.City = "Varna";

            dbContext1.SaveChanges();
            dbContext2.SaveChanges();

            dbContext1.Dispose();
            dbContext2.Dispose();
        }

        private static void PlaceNewOrder(
            int orderId, string customerId = null,
            int? employeeId = null, DateTime? orderDate = null,
            DateTime? requireDate = null, DateTime? shippedDate = null,
            int? shipVia = null, decimal? freight = null,
            string shipName = null, string shipAddress = null,
            string shipCity = null, string shipRegion = null,
            string shipPostalCode = null, string shipCountry = null)
        {
            //9. Create a method that places a new order in the Northwind database. The order 
            //should contain several order items. Use transaction to ensure the data consistency.

            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                Order newOrder = new Order()
                {
                    CustomerID = customerId,
                    EmployeeID = employeeId,
                    Freight = freight,
                    OrderDate = orderDate,
                    OrderID = orderId,
                    RequiredDate = requireDate,
                    ShipAddress = shipAddress,
                    ShipCity = shipCity,
                    ShipCountry = shipCountry,
                    ShipName = shipName,
                    ShippedDate = shippedDate,
                    ShipPostalCode = shipPostalCode,
                    ShipRegion = shipRegion,
                    ShipVia = shipVia,
                };

                dbContext.Orders.Add(newOrder);

                dbContext.SaveChanges();
            }
        }

        static decimal? GetIncome(string supplierName, DateTime startDate, DateTime endDate)
        {
            //10. Create a stored procedures in the Northwind database for finding the total incomes 
            //for given supplier name and period (start date, end date). Implement a C# method that
            //calls the stored procedure and returns the retuned record set.

            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                decimal? totalncome = dbContext.usp_GetTotalIncome(supplierName, startDate, endDate).ToList().FirstOrDefault();

                return totalncome;
            }
        }
    }
}
