
using MassTransit;
using PlayedCouponsApi.Consumers;
using PlayedCouponsApi.Services;
using Shared;

namespace PlayedCouponsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            builder.Services.AddMassTransit(configurator =>
            {


                configurator.AddConsumer<OrderComplatedEventConsumer>();
                configurator.UsingRabbitMq((contex, _configure) =>
                {
                    _configure.Host(builder.Configuration["RabbitMq"]);
                    _configure.ReceiveEndpoint(RabbitMQSettings.PlayedCouponsApi_ComplatedEventQueue, e => e.ConfigureConsumer<OrderComplatedEventConsumer>(contex));

                });
            });


            builder.Services.AddSingleton<MongoDBService>();
            var app = builder.Build();

          

            app.Run();
        }
    }
}
