
using CustomerTransactionsApi.Consumers;
using CustomerTransactionsApi.Data;
using CustomerTransactionsApi.Models;
using HealthChecks.UI.Client;
using MassTransit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace CustomerTransactionsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);




            var connectionstring = builder.Configuration.GetConnectionString("AppDbConnectionString");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionstring,ServerVersion.AutoDetect(connectionstring)));

            builder.Services.AddHealthChecks()
         .AddMySql("Server=localhost;Port=100;Database=Products;User=root;Password=test123");

            builder.Services.AddMassTransit(configurator =>
            {
                //MailGetEventRequestConsumer
                configurator.AddConsumer<AddCustomerConsuners>();
                configurator.AddConsumer<CustomerLoginCheckConsumers>();
                configurator.AddConsumer<MailGetEventRequestConsumer>();
                configurator.UsingRabbitMq((contex, _configure) =>
                {
                    _configure.Host(builder.Configuration["RabbitMq"]);

                    _configure.ReceiveEndpoint(RabbitMQSettings.CustomerTransactionsApi_CustomeraddEventQueue, e => e.ConfigureConsumer<AddCustomerConsuners>(contex));

                    _configure.ReceiveEndpoint(RabbitMQSettings.CustomerTransactionsApi_CustomerCheckRequest, e => e.ConfigureConsumer<CustomerLoginCheckConsumers>(contex));


                    _configure.ReceiveEndpoint(RabbitMQSettings.CustomerTransactionsApi_MailGetEventQueue, e => e.ConfigureConsumer<MailGetEventRequestConsumer>(contex));
                });
            });


            var app = builder.Build();

            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.Run();
        }
    }
}
