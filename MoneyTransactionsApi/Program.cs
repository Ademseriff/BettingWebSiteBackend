
using MassTransit;
using MoneyTransactionsApi.Consumers;
using MoneyTransactionsApi.WorkerEventDb;
using Shared;

namespace MoneyTransactionsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddMassTransit(configurator =>
            {

                configurator.AddConsumer<MoneyDecreaseEventConsumer>();
                configurator.UsingRabbitMq((contex, _configure) =>
                {
                    _configure.Host(builder.Configuration["RabbitMq"]);
                    _configure.ReceiveEndpoint(RabbitMQSettings.MoneyTransactionsApi_MoneyDecreaseEventqueue, e => e.ConfigureConsumer<MoneyDecreaseEventConsumer>(contex));

                });
            });
            builder.Services.AddSingleton<PublisEventDb>();
            var app = builder.Build();

            

            app.Run();
        }
    }
}
