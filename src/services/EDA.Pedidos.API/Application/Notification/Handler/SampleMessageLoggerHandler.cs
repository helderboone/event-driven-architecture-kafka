using EDA.Core;
using EDA.Pedidos.API.Messages;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace EDA.Pedidos.API.Application.Notification.Handler
{
    public class SampleMessageLoggerHandler : INotificationHandler<MessageNotification<SampleMessage>>
    {
        private readonly ILogger<SampleMessageLoggerHandler> _logger;

        public SampleMessageLoggerHandler(ILogger<SampleMessageLoggerHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(MessageNotification<SampleMessage> notification, CancellationToken cancellationToken)
        {
            var message = notification.Message;

            _logger.LogInformation(
                $"Sample message received with key: {message.Key} and value: {message.SomeProperty}");

            return Task.CompletedTask;
        }
    }
}