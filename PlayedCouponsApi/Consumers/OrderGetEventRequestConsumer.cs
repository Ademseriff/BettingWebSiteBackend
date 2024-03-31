using MassTransit;
using MassTransit.Caching.Internals;
using MongoDB.Driver;
using PlayedCouponsApi.Models;
using PlayedCouponsApi.Services;
using Shared.Events;

namespace PlayedCouponsApi.Consumers
{
    public class OrderGetEventRequestConsumer : IConsumer<OrderGetEventRequest>
    {
        private readonly MongoDBService mongoDBService;
        private readonly IPublishEndpoint publishEndpoint;
        public OrderGetEventResponseEvent orderGetEventResponseEvent = new();
        public OrderGetEventRequestConsumer(MongoDBService mongoDBService,IPublishEndpoint publishEndpoint)
        {
            this.mongoDBService = mongoDBService;
            this.publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<OrderGetEventRequest> context)
        {
            var basketCollection = mongoDBService.GetCollection<Basket>();
            var allBaskets = await basketCollection.Find(c => c.state == Shared.Enums.StateEnum.suspend).ToListAsync();
            if(allBaskets != null)
            {
                orderGetEventResponseEvent.OrderGetEventId = Guid.NewGuid().ToString();
                orderGetEventResponseEvent.coupunContents = allBaskets.Select(c => new Shared.Messages.CoupunContentEventMessage()
                {
                    PaidMoney = c.PaidMoney,
                    TotalMoney = c.TotalMoney,
                    state = Shared.Enums.StateEnum.suspend,
                    TotalRate = c.TotalRate,
                    orderContentContents = c.contentLists.Select(c => new Shared.Messages.OrderContentContentEventMessage()
                    {
                        MatchSide = c.MatchSide,
                        Tc = c.Tc,
                        Team1 = c.Team1,
                        Team2 = c.Team2
                    }).ToList()
                }).ToList();

               await publishEndpoint.Publish(orderGetEventResponseEvent);
            }

           


        }
    }
}
