using EventStore.Client;
using Shared.Events;
using System.Text.Json;

namespace MoneyTransactionsApi.WorkerEventDb
{
    public class PublishEventDbPlus
    {
        public async Task Publis(string streamName, MoneyIncreaseEvent moneyIncreaseEvent)
        {
            const string connectionString = "esdb://admin:changeit@localhost:2113?tls=false&tlsVerifyCert=false";
            //const string connectionString = "tcp://admin:changeit@localhost:1113";
            var settings = EventStoreClientSettings.Create(connectionString);

            try
            {
                using var client = new EventStoreClient(settings);

                EventData eventData = new(Uuid.NewUuid(), moneyIncreaseEvent.GetType().Name, JsonSerializer.SerializeToUtf8Bytes(moneyIncreaseEvent));

                await client.AppendToStreamAsync(
                    streamName: streamName,
                    expectedState: StreamState.Any,
                    eventData: new[] { eventData }
                );
            }
            catch (Exception ex)
            {
                // Hata mesajını loglayabilir veya konsola yazdırabilirsiniz
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                // veya loglama kütüphanenizi kullanarak hata logunu kaydedebilirsiniz
                // Logger.Log($"Hata oluştu: {ex.Message}", ex);
            }
        }
    }
}
