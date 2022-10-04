using Microsoft.EntityFrameworkCore;
using Phone_Book.Models;

namespace Phone_Book.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PhoneDb;Trusted_Connection=true");
        }

        public DbSet<PhoneBook> PhoneBooks { get; set; }
    }
}
