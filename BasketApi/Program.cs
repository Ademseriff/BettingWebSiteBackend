
using BasketApi.Consumers;
using BasketApi.Data;
using HealthChecks.UI.Client;
using MassTransit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace BasketApi
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
                //BasketClearEventConsumer
                configurator.AddConsumer<BasketAddEventConsumer>();
                configurator.AddConsumer<BasketItemGetRepuestEventConsumer>();
                configurator.AddConsumer<BasketClearEventConsumer>();
                configurator.UsingRabbitMq((contex, _configure) =>
                {
                    _configure.Host(builder.Configuration["RabbitMq"]);
                    _configure.ReceiveEndpoint(RabbitMQSettings.BasketApi_ItemAddqueue, e => e.ConfigureConsumer<BasketAddEventConsumer>(contex));
                    _configure.ReceiveEndpoint(RabbitMQSettings.BasketApi_BasketItemGetRepuestEvent, e => e.ConfigureConsumer<BasketItemGetRepuestEventConsumer>(contex));
                    _configure.ReceiveEndpoint(RabbitMQSettings.BasketApi_ClearBasketEventqueue, e => e.ConfigureConsumer<BasketClearEventConsumer>(contex));
                });
            });



            var app = builder.Build();
            app.UseHealthChecks("/health",new HealthCheckOptions
            {
                ResponseWriter =  UIResponseWriter.WriteHealthCheckUIResponse
            });
           

            app.Run();
        }
    }
}
