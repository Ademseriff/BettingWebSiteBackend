
namespace HealthCheckApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHealthChecksUI(settings =>
            {
                settings.AddHealthCheckEndpoint("Basket APÝ", "http://localhost:5045/health");
                settings.AddHealthCheckEndpoint("Customer Transactions Api", "http://localhost:5123/health");
                settings.AddHealthCheckEndpoint("Match Odds Api", "http://localhost:5129/health");
                settings.AddHealthCheckEndpoint("Money Transactions Api", "http://localhost:5233/health");
                settings.AddHealthCheckEndpoint("Played Coupons Api", "http://localhost:5270/health");
                settings.AddHealthCheckEndpoint("Mail APÝ", "http://localhost:5064/health");
             

            })
            .AddPostgreSqlStorage("Server=127.0.0.1;Port=5432;Database=HealtCheckDb;User Id=admin;Password=123456;");
          

            var app = builder.Build();


            app.UseHealthChecksUI(settings => 
            settings.UIPath = "/health-ui"

            );


            app.Run();
        }
    }
}
