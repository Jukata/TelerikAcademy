namespace Blog.Data
{
    using System.Data.Entity;
    using Blog.Models;

    public class BlogDbContext : DbContext
    {
        public BlogDbContext()
            : base("BlogDB")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
