
using HealthChecks.UI.Client;
using MassTransit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using MoneyTransactionsApi.Consumers;
using MoneyTransactionsApi.Data;
using MoneyTransactionsApi.WorkerEventDb;
using Shared;

namespace MoneyTransactionsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var connectionstring = builder.Configuration.GetConnectionString("AppDbConnectionString");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring)));

            builder.Services.AddHealthChecks()
        .AddMySql("Server=localhost;Port=100;Database=Products;User=root;Password=test123");

            builder.Services.AddMassTransit(configurator =>
            {
                //MoneyIncreaseEventConsumer
                configurator.AddConsumer<MoneyDecreaseEventConsumer>();
                configurator.AddConsumer<MoneyIncreaseEventConsumer>();
                configurator.UsingRabbitMq((contex, _configure) =>
                {
                    _configure.Host(builder.Configuration["RabbitMq"]);
                    _configure.ReceiveEndpoint(RabbitMQSettings.MoneyTransactionsApi_MoneyDecreaseEventqueue, e => e.ConfigureConsumer<MoneyDecreaseEventConsumer>(contex));
                    _configure.ReceiveEndpoint(RabbitMQSettings.MoneyTransactionApi_AddMoneyEventqueue, e => e.ConfigureConsumer<MoneyIncreaseEventConsumer>(contex));
                });
            });
          
            builder.Services.AddSingleton<PublisEventDb>();
            builder.Services.AddSingleton<PublishEventDbPlus>();
            builder.Services.AddSingleton<SubscuriberEventDb>();
            var app = builder.Build();


            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.Run();
        }
    }
}
