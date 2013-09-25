namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystem.Data.StudentSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //Faculty fmi = new Faculty() { Name = "fmi" };
            //Faculty fcsu = new Faculty() { Name = "fcsu" };

            //Course databases = new Course { Description = "Database course", Name = "Databases", };
            //Course cSharp = new Course { Description = "Programming with CSharp course", Name = "CSharp", };
            //Course java = new Course { Description = "Programming with Java course", Name = "Java", };
            //Course windowsForms = new Course { Description = "Windows Forms course", Name = "WinForms", };

            //fmi.Courses.Add(java);
            //fmi.Courses.Add(cSharp);
            //fcsu.Courses.Add(databases);
            //fcsu.Courses.Add(windowsForms);

            //Homework dbHomework1 = new Homework() { Content = "SQL", TimeSent = DateTime.Now };
            //Homework dbHomework2 = new Homework() { Content = "T-SQL", TimeSent = DateTime.Now };

            //databases.Homeworks.Add(dbHomework1);
            //databases.Homeworks.Add(dbHomework2);

            //Homework csHomework1 = new Homework() { Content = "C# primitive types and variables", TimeSent = DateTime.Now };
            //Homework csHomework2 = new Homework() { Content = "C# conditional statements", TimeSent = DateTime.Now };
            //Homework csHomework3 = new Homework() { Content = "C# console input output", TimeSent = DateTime.Now };
            //Homework csHomework4 = new Homework() { Content = "C# Loops", TimeSent = DateTime.Now };

            //cSharp.Homeworks.Add(csHomework1);
            //cSharp.Homeworks.Add(csHomework2);
            //cSharp.Homeworks.Add(csHomework3);
            //cSharp.Homeworks.Add(csHomework4);

            //Homework wfHomework1 = new Homework() { Content = "Intro in windows forms ", TimeSent = DateTime.Now };
            //Homework wfHomework2 = new Homework() { Content = "Databinding in windows forms ", TimeSent = DateTime.Now };

            //windowsForms.Homeworks.Add(wfHomework1);
            //windowsForms.Homeworks.Add(wfHomework2);

            //Homework javaHomework = new Homework() { Content = "Oject-oriented principles.", TimeSent = DateTime.Now };

            //java.Homeworks.Add(javaHomework);

            Student sn = new Student() { FirstName = "Svetlin", LastName = "Nakov", FacultyNumber = "987654321" };
            //sn.Courses.Add(databases);
            //sn.Courses.Add(java);

            Student nk = new Student() { FirstName = "Nikolay", LastName = "Kostov", FacultyNumber = "123456789" };

            //nk.Courses.Add(cSharp);
            //nk.Courses.Add(windowsForms);

            //context.Courses.AddOrUpdate(x => x.Name, cSharp);
            //context.Courses.AddOrUpdate(x => x.Name, windowsForms);
            //context.Faculties.AddOrUpdate(fmi);
            //context.Faculties.AddOrUpdate(fcsu);

            context.Students.AddOrUpdate(x => x.FacultyNumber, sn, nk);
            context.SaveChanges();
        }
    }
}
