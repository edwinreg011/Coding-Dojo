using Microsoft.EntityFrameworkCore;

namespace BeltExam.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}

        public DbSet<User> Users {get;set;}
        public DbSet<Meeting> Meetings {get;set;}
        public DbSet<Attendant> Attendants {get;set;} 
    }
}