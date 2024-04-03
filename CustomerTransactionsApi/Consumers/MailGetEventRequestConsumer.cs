using CustomerTransactionsApi.Data;
using CustomerTransactionsApi.Models;
using MassTransit;
using MassTransit.Transports;
using Microsoft.EntityFrameworkCore;
using Shared.Events;

namespace CustomerTransactionsApi.Consumers
{
    public class MailGetEventRequestConsumer : IConsumer<MailGetEventRequest>
    {
        private readonly AppDbContext appDbContext;
        private readonly IPublishEndpoint publishEndpoint;

        public MailGetEventRequestConsumer(AppDbContext appDbContext,IPublishEndpoint publishEndpoint)
        {
            this.appDbContext = appDbContext;
            this.publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<MailGetEventRequest> context)
        {
            Products pr = await appDbContext.Products
           .Where(p => p.HumanIdentity == context.Message.Tc ).FirstOrDefaultAsync();


            if (pr == null)
            {
               

            }
            else if (pr.EMail != null)
            {
               
                    await publishEndpoint.Publish(new MailGetEventResponse() { Email = pr.EMail });
                
            }
        }
    }
}
