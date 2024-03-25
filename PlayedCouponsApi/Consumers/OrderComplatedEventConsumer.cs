using MassTransit;
using MongoDB.Driver;
using PlayedCouponsApi.Models;
using PlayedCouponsApi.Services;
using Shared.Events;

namespace PlayedCouponsApi.Consumers
{
    public class OrderComplatedEventConsumer : IConsumer<OrderComplatedEvent>
    {
        private readonly MongoDBService mongoDBService;

        public OrderComplatedEventConsumer(MongoDBService mongoDBService)
        {
            this.mongoDBService = mongoDBService;
        }

        public async Task Consume(ConsumeContext<OrderComplatedEvent> context)
        {
            try
            {
                IMongoCollection<Basket> collection = mongoDBService.GetCollection<Basket>();
                await collection.InsertOneAsync(new Basket
                {
                   
                   PaidMoney = context.Message.PaidMoney,
                   TotalMoney = context.Message.TotalMoney,
                   TotalRate = context.Message.TotalRate,
                   state = Shared.Enums.StateEnum.suspend,
                   contentLists = context.Message.contentLists.Select(oi => new BasketContentList()
                   {
                       MatchSide = oi.MatchSide,
                       Tc = oi.Tc,
                       Team1 = oi.Team1,
                       Team2 = oi.Team2,
                   }).ToList()
                });
              
            }
            catch (Exception ex)
            {
                // Hata mesajını loglama veya hata ayıklama amacıyla yazdırma
                Console.WriteLine($"Hata oluştu: {ex.Message}");
            }
        }
    }
}
