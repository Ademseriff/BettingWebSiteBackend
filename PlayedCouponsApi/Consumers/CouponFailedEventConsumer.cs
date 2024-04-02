using MassTransit;
using MongoDB.Driver;
using PlayedCouponsApi.Models;
using PlayedCouponsApi.Services;
using Shared.Events;

namespace PlayedCouponsApi.Consumers
{
    public class CouponFailedEventConsumer : IConsumer<CouponFailedEvent>
    {
        private readonly MongoDBService mongoDBService;

        public CouponFailedEventConsumer(MongoDBService mongoDBService)
        {
            this.mongoDBService = mongoDBService;
        }

        public async Task Consume(ConsumeContext<CouponFailedEvent> context)
        {
            try
            {
                var filter = Builders<Basket>.Filter.Eq(x => x.TotalMoney, context.Message.TotalMoney) & Builders<Basket>.Filter.Eq(x => x.TotalRate, context.Message.TotalRate);

                var update = Builders<Basket>.Update
                        .Set(x => x.state, Shared.Enums.StateEnum.failed);

                var result = await mongoDBService.GetCollection<Basket>().UpdateOneAsync(filter, update);

            }
            catch (Exception ex)
            {
                // Hata mesajını loglama veya hata ayıklama amacıyla yazdırma
                Console.WriteLine($"Hata oluştu: {ex.Message}");
            }
        }
    }
}
