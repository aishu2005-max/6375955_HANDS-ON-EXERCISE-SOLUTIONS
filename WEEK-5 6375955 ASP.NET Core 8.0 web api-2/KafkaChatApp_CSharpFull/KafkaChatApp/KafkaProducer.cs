using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace KafkaChatApp
{
    public class KafkaProducer : IDisposable
    {
        private readonly IProducer<Null, string> _producer;
        private readonly string _topic;

        public KafkaProducer(string bootstrapServers, string topic)
        {
            _topic = topic;
            var config = new ProducerConfig
            {
                BootstrapServers = bootstrapServers,
                Acks = Acks.Leader
            };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task ProduceMessageAsync(string message)
        {
            try
            {
                await _producer.ProduceAsync(_topic, new Message<Null, string> { Value = message });
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Produce error: {e.Error.Reason}");
            }
        }

        public void Dispose()
        {
            try { _producer?.Flush(TimeSpan.FromSeconds(5)); } catch { }
            _producer?.Dispose();
        }
    }
}
