
using BasketApi.Consumers;
using BasketApi.Data;
using MassTransit;
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

            builder.Services.AddMassTransit(configurator =>
            {
                //CustomerLoginCheckConsumers
                configurator.AddConsumer<BasketAddEventConsumer>();
                configurator.AddConsumer<BasketItemGetRepuestEventConsumer>();
                configurator.UsingRabbitMq((contex, _configure) =>
                {
                    _configure.Host(builder.Configuration["RabbitMq"]);
                    _configure.ReceiveEndpoint(RabbitMQSettings.BasketApi_ItemAddqueue, e => e.ConfigureConsumer<BasketAddEventConsumer>(contex));
                    _configure.ReceiveEndpoint(RabbitMQSettings.BasketApi_BasketItemGetRepuestEvent, e => e.ConfigureConsumer<BasketItemGetRepuestEventConsumer>(contex));
                });
            });



            var app = builder.Build();

           

            app.Run();
        }
    }
}
