using EventStore.Client;
using MoneyTransactionsApi.Data;

namespace MoneyTransactionsApi.WorkerEventDb
{
    public class SubscuriberEventDb
    {
      


        public async Task Subscuriber(string streamName, Func<StreamSubscription, ResolvedEvent, CancellationToken, Task> eventappeared)
        {
            const string connectionString = "esdb://admin:changeit@localhost:2113?tls=false&tlsVerifyCert=false";
            //const string connectionString = "tcp://admin:changeit@localhost:1113";
            var settings = EventStoreClientSettings.Create(connectionString);

            try
            {
                using var client = new EventStoreClient(settings);

              await  client.SubscribeToStreamAsync(
                    streamName: streamName,
                    start:FromStream.Start,
                    eventAppeared: eventappeared,
                    subscriptionDropped:(x,y,z) => Console.WriteLine("koptu")
                    );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.ToString()}");
            }
        }
    }
}
