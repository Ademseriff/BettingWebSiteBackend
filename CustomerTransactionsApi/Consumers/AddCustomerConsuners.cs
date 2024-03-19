using CustomerTransactionsApi.Data;
using CustomerTransactionsApi.Models;
using MassTransit;
using Shared.Events;
using System.Net.Http.Headers;

namespace CustomerTransactionsApi.Consumers
{
    public class AddCustomerConsuners : IConsumer<CustomerAddedEvent>
    {
        private readonly AppDbContext _appContext;

        public AddCustomerConsuners(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public async Task Consume(ConsumeContext<CustomerAddedEvent> context)
        {
            Products product = new();

            if (context.Message != null)
            {
                product.Id = new Guid();
                product.HumanIdentity = context.Message.HumanIdentity;
                product.Name = context.Message.Name;
                product.Surname = context.Message.Surname;
                product.Password = context.Message.Password;
                product.TotalPrice = "0";
                await _appContext.AddAsync(product);
                await _appContext.SaveChangesAsync();
            }
            
        }
    }
}
