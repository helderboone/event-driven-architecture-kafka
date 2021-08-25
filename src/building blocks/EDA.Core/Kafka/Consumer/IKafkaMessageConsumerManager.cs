using System.Threading;

namespace EDA.Core.Kafka.Consumer
{
    public interface IKafkaMessageConsumerManager
    {
        void StartConsumers(CancellationToken cancellationToken);
    }
}