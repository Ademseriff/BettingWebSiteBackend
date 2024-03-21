using BasketApi.Data;
using BasketApi.Models;
using MassTransit;
using Shared.Events;

namespace BasketApi.Consumers
{
    public class BasketAddEventConsumer : IConsumer<BasketAddedEvent>
    {
        private readonly AppDbContext appDbContext;

        public BasketAddEventConsumer(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task Consume(ConsumeContext<BasketAddedEvent> context)
        {
            if(context != null)
            {
                Basket basket = new()
                {
                    Id = new Guid(),
                    Tc = context.Message.Tc,
                    MatchSide = context.Message.MatchSide,
                    Rate = context.Message.Rate,
                    Team1 = context.Message.Team1,
                    Team2 = context.Message.Team2
                };
                await appDbContext.AddAsync<Basket>(basket);
                await appDbContext.SaveChangesAsync();
            }

        }
    }
}
