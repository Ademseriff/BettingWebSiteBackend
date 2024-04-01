using MassTransit;
using Microsoft.EntityFrameworkCore;
using MoneyTransactionsApi.Data;
using MoneyTransactionsApi.ViewModel;
using MoneyTransactionsApi.WorkerEventDb;
using Shared.Events;

namespace MoneyTransactionsApi.Consumers
{
    public class MoneyIncreaseEventConsumer : IConsumer<MoneyIncreaseEvent>
    {
        private readonly PublishEventDbPlus publishEventDbPlus;
        private readonly AppDbContext appDbContext;

        public MoneyIncreaseEventConsumer(PublishEventDbPlus publishEventDbPlus,AppDbContext appDbContext)
        {
            this.publishEventDbPlus = publishEventDbPlus;
            this.appDbContext = appDbContext;
        }

        public async Task Consume(ConsumeContext<MoneyIncreaseEvent> context)
        {
            await publishEventDbPlus.Publis(context.Message.Tc, context.Message);
            await Task.Delay(1000);

            Products products = await appDbContext.Products.FirstOrDefaultAsync(o => o.HumanIdentity == context.Message.Tc);

            if (products != null)
            {
                int totalPrice = int.Parse(products.TotalPrice);
                int money = int.Parse(context.Message.Money);
                totalPrice += money;
                products.TotalPrice = totalPrice.ToString();
                await appDbContext.SaveChangesAsync();
            }

        }
    }
}
