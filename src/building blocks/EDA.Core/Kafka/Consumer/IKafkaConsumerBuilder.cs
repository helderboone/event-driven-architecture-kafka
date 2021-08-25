using Confluent.Kafka;

namespace EDA.Core.Kafka.Consumer
{
    public interface IKafkaConsumerBuilder
    {
        IConsumer<string, string> Build();
    }
}