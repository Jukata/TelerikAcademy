using Northwind.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Client
{
    public static class CustomerDAO
    {
        //2. Create a DAO class with static methods which provide functionality 
        //for inserting, modifying and deleting customers. Write a testing class.

        public static void Delete(string customerId)
        {
            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                Customer customer = dbContext.Customers.Find(customerId);
                dbContext.Customers.Remove(customer);
                dbContext.SaveChanges();
            }
        }

        public static void Modify(string customerId, string companyName /*= null, string address = null,
            string city = null, string contactName = null, string contactTitle = null, string country = null,
            string fax = null, string phone = null, string postalCode = null, string region = null*/)
        {
            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                Customer customer = dbContext.Customers.Find(customerId);
                customer.CompanyName = companyName;
                dbContext.SaveChanges();
            }
        }

        public static void Insert(string customerId, string companyName, string address = null,
            string city = null, string contactName = null, string contactTitle = null, string country = null,
            string fax = null, string phone = null, string postalCode = null, string region = null)
        {
            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                Customer newCustomer = new Customer()
                {
                    Address = address,
                    City = city,
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    Country = country,
                    CustomerID = customerId,
                    Fax = fax,
                    Phone = phone,
                    PostalCode = postalCode,
                    Region = region
                };

                dbContext.Customers.Add(newCustomer);
                dbContext.SaveChanges();
            }
        }
    }
}
