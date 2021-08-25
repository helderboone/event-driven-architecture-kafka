using Confluent.Kafka;

namespace EDA.Core.Kafka.Producer
{
    public interface IKafkaProducerBuilder
    {
        IProducer<string, string> Build();
    }
}