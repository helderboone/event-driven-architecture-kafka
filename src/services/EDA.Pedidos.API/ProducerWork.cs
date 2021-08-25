using EDA.Core.Kafka.Producer;
using EDA.Pedidos.API.Messages;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDA.Pedidos.API
{
    public class ProducerWork : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMessageProducer _messageProducer;

        public ProducerWork(ILogger<Worker> logger, IMessageProducer messageProducer)
        {
            _logger = logger;
            _messageProducer = messageProducer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var count = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                var sampleMessage = new SampleMessage($"sample-key-{count}", "sample-property");
                var pedidoPagoMessage = new PedidoPagoMessage(Guid.NewGuid(), Guid.NewGuid());
                var pedidoIniciadoMessage = new PedidoIniciadoMessage(Guid.NewGuid(), Guid.NewGuid());
                await _messageProducer.ProduceAsync(sampleMessage.Key, sampleMessage, stoppingToken);
                await _messageProducer.ProduceAsync($"{count}", pedidoPagoMessage, stoppingToken);
                await _messageProducer.ProduceAsync($"{count}", pedidoIniciadoMessage, stoppingToken);

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
                count++;
            }
        }
    }
}