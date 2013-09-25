using StudentSystem.Data;
using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StudentSystem.Data.Migrations;

namespace StudentSystem.Client
{
    public class Program
    {
        static void Main()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());

            using (StudentSystemContext dbContext = new StudentSystemContext())
            {
                foreach (Student student in dbContext.Students)
                {
                    Console.WriteLine("{0} {1} - {2}",
                        student.FirstName, student.LastName, student.FacultyNumber);
                }
            }
        }
    }
}
