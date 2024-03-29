using MassTransit;
using MoneyTransactionsApi.WorkerEventDb;
using Shared.Events;

namespace MoneyTransactionsApi.Consumers
{
    public class MoneyDecreaseEventConsumer : IConsumer<MoneyDecreaseEvent>
    {
        private readonly PublisEventDb publisEventDb;

        public MoneyDecreaseEventConsumer(PublisEventDb publisEventDb)
        {
            this.publisEventDb = publisEventDb;
        }

        public async Task Consume(ConsumeContext<MoneyDecreaseEvent> context)
        {
           await publisEventDb.Publis(context.Message.Tc, context.Message);
        }
    }
}
