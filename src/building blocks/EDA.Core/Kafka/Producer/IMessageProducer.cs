using System.Threading;
using System.Threading.Tasks;

namespace EDA.Core.Kafka.Producer
{
    public interface IMessageProducer
    {
        Task ProduceAsync(string key, IMessage message, CancellationToken cancellationToken);
    }
}