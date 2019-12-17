using Microsoft.EntityFrameworkCore;

namespace FirstEFcore.Models
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options) {}
        public DbSet<User> Users {get;set;}
    }
}