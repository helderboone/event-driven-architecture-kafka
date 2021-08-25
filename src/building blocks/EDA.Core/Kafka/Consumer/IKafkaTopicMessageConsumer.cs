using System.Threading;

namespace EDA.Core.Kafka.Consumer
{
    public interface IKafkaTopicMessageConsumer
    {
        void StartConsuming(string topic, CancellationToken cancellationToken);
    }
}