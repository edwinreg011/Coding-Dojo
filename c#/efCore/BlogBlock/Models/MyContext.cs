using Microsoft.EntityFrameworkCore;

namespace BlogBlock.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}

        public DbSet<User> Users {get;set;}
        public DbSet<Blog> Blogs {get;set;}
    }
}