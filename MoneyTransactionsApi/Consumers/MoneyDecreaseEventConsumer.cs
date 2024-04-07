using MassTransit;
using Microsoft.EntityFrameworkCore;
using MoneyTransactionsApi.Data;
using MoneyTransactionsApi.ViewModel;
using MoneyTransactionsApi.WorkerEventDb;
using Shared.Events;
using System.Text.Json;

namespace MoneyTransactionsApi.Consumers
{
    public class MoneyDecreaseEventConsumer : IConsumer<MoneyDecreaseEvent>
    {
        private readonly PublisEventDb publisEventDb;
        private readonly SubscuriberEventDb subscuriberEventDb;
        private readonly AppDbContext appDbContext;

        public MoneyDecreaseEventConsumer(PublisEventDb publisEventDb, SubscuriberEventDb subscuriberEventDb, AppDbContext appDbContext)
        {
            this.publisEventDb = publisEventDb;
            this.subscuriberEventDb = subscuriberEventDb;
            this.appDbContext = appDbContext;
        }

        public async Task Consume(ConsumeContext<MoneyDecreaseEvent> context)
        {
           await publisEventDb.Publis(context.Message.Tc, context.Message);
           await Task.Delay(1000);

            Products products = await appDbContext.Products.FirstOrDefaultAsync(o => o.HumanIdentity == context.Message.Tc);

            if(products != null)
            {
                int totalPrice = int.Parse(products.TotalPrice);
                int money = int.Parse(context.Message.Money);
                if (money > totalPrice)
                {
                    totalPrice = 0;
                }
                else
                {
                    totalPrice -= money;
                }
                products.TotalPrice = totalPrice.ToString();
                await appDbContext.SaveChangesAsync();
            }
            

        }
    }
}
