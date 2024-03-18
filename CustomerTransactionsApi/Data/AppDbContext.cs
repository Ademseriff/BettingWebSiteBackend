using CustomerTransactionsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerTransactionsApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
    }
}
