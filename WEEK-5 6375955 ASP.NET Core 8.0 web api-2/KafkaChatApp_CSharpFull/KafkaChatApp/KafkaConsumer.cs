using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace KafkaChatApp
{
    public class KafkaConsumer : IDisposable
    {
        private readonly string _topic;
        private readonly IConsumer<Ignore, string> _consumer;
        private CancellationTokenSource? _cts;

        public KafkaConsumer(string bootstrapServers, string groupId, string topic)
        {
            _topic = topic;
            var config = new ConsumerConfig
            {
                BootstrapServers = bootstrapServers,
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnablePartitionEof = false
            };
            _consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        }

        public Task StartAsync(Action<string> onMessage)
        {
            _cts = new CancellationTokenSource();
            _consumer.Subscribe(_topic);
            return Task.Run(() =>
            {
                try
                {
                    while (!_cts.IsCancellationRequested)
                    {
                        var cr = _consumer.Consume(_cts.Token);
                        if (cr?.Message?.Value != null)
                        {
                            onMessage(cr.Message.Value);
                        }
                    }
                }
                catch (OperationCanceledException) { }
                catch (ConsumeException ex)
                {
                    Console.WriteLine($"Consume error: {ex.Error.Reason}");
                }
            }, _cts.Token);
        }

        public void Stop()
        {
            _cts?.Cancel();
            try { _consumer.Unsubscribe(); } catch { }
        }

        public void Dispose()
        {
            try { _consumer.Close(); } catch { }
            _consumer.Dispose();
            _cts?.Dispose();
        }
    }
}
