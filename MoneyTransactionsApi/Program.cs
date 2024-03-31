
using MassTransit;
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
            builder.Services.AddSingleton<SubscuriberEventDb>();
            var app = builder.Build();

            

            app.Run();
        }
    }
}
