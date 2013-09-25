using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.Model;

namespace TelerikAcademy.Client
{
    class Program
    {
        static void Main()
        {
            //1. 
            NPlusOneQueryProblem();

            Console.ReadLine();
            Console.Clear();

            //2. 
            ToListProblem();
        }

        private static void NPlusOneQueryProblem()
        {
            //1. Using Entity Framework write a SQL query to select all employees from the 
            //Telerik Academy database and later print their name, department and town.
            //Try the both variants: with and without .Include(…). Compare the number of 
            //executed SQL statements and the performance.
            using (TelerikAcademyEntities dbContext = new TelerikAcademyEntities())
            {
                foreach (Employee employee in dbContext.Employees)
                {
                    Console.WriteLine("First name = {0}, Last name = {1}, Department = {2}, Town = {3}.",
                        employee.FirstName, employee.LastName, employee.Department.Name, employee.Address.Town.Name);
                }

                Console.ReadLine();
                Console.Clear();

                foreach (Employee employee in dbContext.Employees
                                                       .Include("Department")
                                                       .Include("Address.Town"))
                {
                    Console.WriteLine("First name = {0}, Last name = {1}, Department = {2}, Town = {3}.",
                        employee.FirstName, employee.LastName, employee.Department.Name, employee.Address.Town.Name);
                }
            }
        }

        private static void ToListProblem()
        {
            //2. Using Entity Framework write a query that selects all employees from the
            //Telerik Academy database, then invokes ToList(), then selects their 
            //addresses, then invokes ToList(), then selects their towns, then invokes 
            //ToList() and finally checks whether the town is "Sofia". Rewrite the 
            //same in more optimized way and compare the performance.
            using (TelerikAcademyEntities dbContext = new TelerikAcademyEntities())
            {
                var townsSlow = dbContext.Employees
                                         .ToList()
                                         .Select(x => x.Address)
                                         .ToList()
                                         .Select(x => x.Town)
                                         .ToList()
                                         .Where(x => x.Name == "Sofia");

                foreach (var town in townsSlow)
                {
                    Console.WriteLine(town.Name);
                }

                Console.ReadLine();
                Console.Clear();

                var townsFast = dbContext.Employees
                                         .Select(x => x.Address)
                                         .Select(x => x.Town)
                                         .Where(x => x.Name == "Sofia");

                foreach (var town in townsFast)
                {
                    Console.WriteLine(town.Name);
                }
            }
        }
    }
}
