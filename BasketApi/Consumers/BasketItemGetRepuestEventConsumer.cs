using BasketApi.Data;
using BasketApi.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared.Events;
using Shared.Messages;

namespace BasketApi.Consumers
{
    public class BasketItemGetRepuestEventConsumer : IConsumer<BasketItemGetRepuestEvent>
    {
        private readonly AppDbContext database;
        private readonly IPublishEndpoint publishEndpoint;

        public BasketItemGetRepuestEventConsumer(AppDbContext appDbContext,IPublishEndpoint publishEndpoint)
        {
            database = appDbContext;
            this.publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<BasketItemGetRepuestEvent> context)
        {
            BasketItemGetResponseEvent basketGetResponseEvent = new();
            List<BasketGetResponseEventMessage> list =await database.baskets
            .Where(x => x.Tc == context.Message.tc).Select(x => new BasketGetResponseEventMessage {
            Tc = x.Tc,
            MatchSide= x.MatchSide,
            Rate= x.Rate,
            Team1= x.Team1,
           Team2 = x.Team2
            }).ToListAsync();

            basketGetResponseEvent.Id = Guid.NewGuid().ToString();
            basketGetResponseEvent.messages = list;
            if (basketGetResponseEvent.messages != null)
            {
                await publishEndpoint.Publish(basketGetResponseEvent);
            }


        }
    }
}
