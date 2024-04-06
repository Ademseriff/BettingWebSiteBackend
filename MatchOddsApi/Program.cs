
using HealthChecks.UI.Client;
using MassTransit;
using MatchOddsApi.Consumers;
using MatchOddsApi.WorkerService;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Shared;
using Shared.Events;

namespace MatchOddsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHealthChecks();
            builder.Services.AddMassTransit(configurator =>
            {

                configurator.AddConsumer<GetMatchOddsConsumers>();
                configurator.UsingRabbitMq((contex, _configure) =>
                {
                    _configure.Host(builder.Configuration["RabbitMq"]);

                    _configure.ReceiveEndpoint(RabbitMQSettings.MatchOddsApi_matchoddsrequestEventQueue, e => e.ConfigureConsumer<GetMatchOddsConsumers>(contex));
                });
            });
            builder.Services.AddSingleton<MatchOddsDataService>();
            var app = builder.Build();

            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.Run();
        }
    }
}
