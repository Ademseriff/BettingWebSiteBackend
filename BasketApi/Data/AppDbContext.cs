using BasketApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Basket> baskets { get; set; }
    }
}
