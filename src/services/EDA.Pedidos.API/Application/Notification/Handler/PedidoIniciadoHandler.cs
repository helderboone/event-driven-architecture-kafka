using EDA.Core;
using EDA.Pedidos.API.Messages;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace EDA.Pedidos.API.Application.Notification.Handler
{
    public class PedidoIniciadoHandler : INotificationHandler<MessageNotification<PedidoIniciadoMessage>>
    {
        private readonly ILogger<PedidoIniciadoHandler> _logger;

        public PedidoIniciadoHandler(ILogger<PedidoIniciadoHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(MessageNotification<PedidoIniciadoMessage> notification, CancellationToken cancellationToken)
        {
            var message = notification.Message;

            _logger.LogInformation($"Pedido iniciado: {message.PedidoId} pelo cliente id: {message.ClientId}");

            return Task.CompletedTask;
        }
    }
}