using EDA.Core;
using EDA.Pedidos.API.Messages;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace EDA.Pedidos.API.Application.Notification.Handler
{
    public class PedidoPagoHandler : INotificationHandler<MessageNotification<PedidoPagoMessage>>
    {
        private readonly ILogger<PedidoPagoHandler> _logger;

        public PedidoPagoHandler(ILogger<PedidoPagoHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(MessageNotification<PedidoPagoMessage> notification, CancellationToken cancellationToken)
        {
            var message = notification.Message;

            _logger.LogInformation($"PedidoId: {message.PedidoId}");

            return Task.CompletedTask;
        }
    }
}