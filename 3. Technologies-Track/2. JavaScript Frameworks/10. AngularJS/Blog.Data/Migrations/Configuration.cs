namespace Blog.Data.Migrations
{
    using Blog.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Blog.Data.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Blog.Data.BlogContext context)
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

            Category catHomework = new Category { Name = "homeworks" };
            Category catJavaScript = new Category { Name = "JavaScript" };
            Category catCharp = new Category { Name = "C#" };

            Post post1 = new Post
            {
                Title = "C#2 Arrays homeworks",
                Content = "We can't do all do homeworks. We don't have enought time.",
                Categories = new HashSet<Category>() { catHomework, catCharp },
            };

            Post post2 = new Post
            {
                Title = "JavaSciprt Frameworks homeworks",
                Content = "Give us more homeworks. We want more more more.",
                Categories = new HashSet<Category>() { catHomework, catJavaScript },
            };

            context.Posts.AddOrUpdate(p => p.Title, post1, post2);
            context.SaveChanges();
        }
    }
}
