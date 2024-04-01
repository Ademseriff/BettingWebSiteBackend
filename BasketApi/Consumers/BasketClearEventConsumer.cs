using BasketApi.Data;
using MassTransit;
using Shared.Events;

namespace BasketApi.Consumers
{
    public class BasketClearEventConsumer : IConsumer<BasketClearEvent>
    {
        private readonly AppDbContext appDbContext;

        public BasketClearEventConsumer(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task Consume(ConsumeContext<BasketClearEvent> context)
        {
            var basketsToRemove = appDbContext.baskets.Where(x => x.Tc.Equals(context.Message.Tc));
            if(basketsToRemove != null ) {
                appDbContext.baskets.RemoveRange(basketsToRemove);
                await appDbContext.SaveChangesAsync();
            }
           
        }
    }
}
