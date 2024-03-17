using MassTransit;
using MatchOddsApi.WorkerService;
using Shared.Events;

namespace MatchOddsApi.Consumers
{
    public class GetMatchOddsConsumers : IConsumer<MatchOddsEventRequest>
    {
        private readonly MatchOddsDataService matchOddsDataService;
        private readonly IPublishEndpoint publishEndpoint;

        public GetMatchOddsConsumers(MatchOddsDataService matchOddsDataService,IPublishEndpoint publishEndpoint)
        {
            this.matchOddsDataService = matchOddsDataService;
            this.publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<MatchOddsEventRequest> context)
        {
            MatchOddsEvent matchOddsEvent = new();
            matchOddsEvent.MatchOddsAllId = new Guid();
            matchOddsEvent.MatchOddsEvents = await matchOddsDataService.GetMatchOdds();

            await publishEndpoint.Publish(matchOddsEvent);
        }
    }
}
