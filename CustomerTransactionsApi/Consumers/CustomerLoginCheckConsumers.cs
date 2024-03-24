using CustomerTransactionsApi.Data;
using CustomerTransactionsApi.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared.Events;

namespace CustomerTransactionsApi.Consumers
{
    public class CustomerLoginCheckConsumers : IConsumer<UserLoginCheckEvent>
    {
        private readonly AppDbContext appDbContext;
        private readonly IPublishEndpoint publishEndpoint;

        public CustomerLoginCheckConsumers(AppDbContext appDbContext,IPublishEndpoint publishEndpoint)
        {
            this.appDbContext = appDbContext;
            this.publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<UserLoginCheckEvent> context)
        {
            UserLoginCheckEventResponse response = new();
            Products pr = await appDbContext.Products
            .Where(p => p.HumanIdentity == context.Message.Tc && p.Password == context.Message.Password).FirstOrDefaultAsync();


            if (pr == null)
            {
                response.IsValid = false;
               await publishEndpoint.Publish(response);

            }
            else if (pr != null) {
                response.IsValid = true;
                if (pr.TotalPrice != null)
                {
                    response.TotalPrice = pr.TotalPrice;
                }
                await publishEndpoint.Publish(response);
            }
        }
    }
}
