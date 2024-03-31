using Microsoft.EntityFrameworkCore;
using MoneyTransactionsApi.ViewModel;

namespace MoneyTransactionsApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
    }
}
