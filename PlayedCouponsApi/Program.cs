
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

                //CouponFailedEventConsumer
                configurator.AddConsumer<OrderComplatedEventConsumer>();
                configurator.AddConsumer<OrderGetEventRequestConsumer>();
                configurator.AddConsumer<CouponComplatedEventConsumer>();
                configurator.AddConsumer<CouponFailedEventConsumer>();
                configurator.UsingRabbitMq((contex, _configure) =>
                {
                    _configure.Host(builder.Configuration["RabbitMq"]);
                    _configure.ReceiveEndpoint(RabbitMQSettings.PlayedCouponsApi_ComplatedEventQueue, e => e.ConfigureConsumer<OrderComplatedEventConsumer>(contex));
                    _configure.ReceiveEndpoint(RabbitMQSettings.PlayedCouponsApi_GetCouponsRequesttQueue, e => e.ConfigureConsumer<OrderGetEventRequestConsumer>(contex));
                    _configure.ReceiveEndpoint(RabbitMQSettings.PlayedCouponsApi_CouponsComplatedEventqueue, e => e.ConfigureConsumer<CouponComplatedEventConsumer>(contex));
                    _configure.ReceiveEndpoint(RabbitMQSettings.PlayedCouponsApi_CouponsFailedEventqueue, e => e.ConfigureConsumer<CouponFailedEventConsumer>(contex));
                });
            });


            builder.Services.AddSingleton<MongoDBService>();
            var app = builder.Build();

          

            app.Run();
        }
    }
}
