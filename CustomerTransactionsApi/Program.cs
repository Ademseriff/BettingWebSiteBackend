
using CustomerTransactionsApi.Consumers;
using CustomerTransactionsApi.Data;
using CustomerTransactionsApi.Models;
using MassTransit;
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


            builder.Services.AddMassTransit(configurator =>
            {
                //CustomerLoginCheckConsumers
                configurator.AddConsumer<AddCustomerConsuners>();
                configurator.AddConsumer<CustomerLoginCheckConsumers>();
                configurator.UsingRabbitMq((contex, _configure) =>
                {
                    _configure.Host(builder.Configuration["RabbitMq"]);

                    _configure.ReceiveEndpoint(RabbitMQSettings.CustomerTransactionsApi_CustomeraddEventQueue, e => e.ConfigureConsumer<AddCustomerConsuners>(contex));

                    _configure.ReceiveEndpoint(RabbitMQSettings.CustomerTransactionsApi_CustomerCheckRequest, e => e.ConfigureConsumer<CustomerLoginCheckConsumers>(contex));
                });
            });


            var app = builder.Build();

            

            app.Run();
        }
    }
}
