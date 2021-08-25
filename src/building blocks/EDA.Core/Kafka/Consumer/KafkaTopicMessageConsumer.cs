using Confluent.Kafka;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;

namespace EDA.Core.Kafka.Consumer
{
    public class KafkaTopicMessageConsumer : IKafkaTopicMessageConsumer
    {
        private readonly IKafkaConsumerBuilder _kafkaConsumerBuilder;
        private readonly ILogger<KafkaTopicMessageConsumer> _logger;
        private readonly IServiceProvider _serviceProvider;

        public KafkaTopicMessageConsumer(ILogger<KafkaTopicMessageConsumer> logger, IKafkaConsumerBuilder kafkaConsumerBuilder, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _kafkaConsumerBuilder = kafkaConsumerBuilder;
            _serviceProvider = serviceProvider;
        }

        public void StartConsuming(string topic, CancellationToken cancellationToken)
        {
            using (var consumer = _kafkaConsumerBuilder.Build())
            {
                _logger.LogInformation($"Starting consumer for {topic}");

                consumer.Subscribe(topic);

                try
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var consumeResult = consumer.Consume(cancellationToken);

                        // TODO: log error if missing header
                        var messageTypeEncoded = consumeResult.Message.Headers.GetLastBytes("message-type");
                        var messageTypeHeader = Encoding.UTF8.GetString(messageTypeEncoded);
                        var messageType = Type.GetType(messageTypeHeader);

                        var message = JsonConvert.DeserializeObject(consumeResult.Message.Value, messageType);
                        var messageNotificationType = typeof(MessageNotification<>).MakeGenericType(messageType);
                        var messageNotification = Activator.CreateInstance(messageNotificationType, message);

                        using (var scope = _serviceProvider.CreateScope())
                        {
                            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                            mediator.Publish(messageNotification, cancellationToken).GetAwaiter().GetResult();
                        }
                        consumer.Commit(consumeResult);
                    }
                }
                catch (OperationCanceledException)
                {
                    // do nothing on cancellation
                }
                catch (ConsumeException ex)
                {
                }
                finally
                {
                    consumer.Close();
                    consumer.Dispose();
                }
            }
        }
    }
}