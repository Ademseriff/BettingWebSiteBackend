
using CustomerTransactionsApi.Data;
using CustomerTransactionsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerTransactionsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionstring = builder.Configuration.GetConnectionString("AppDbConnectionString");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionstring,ServerVersion.AutoDetect(connectionstring)));

            var app = builder.Build();

            

            app.Run();
        }
    }
}
