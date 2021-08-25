using EDA.Core;
using System;

namespace EDA.Pedidos.API.Messages
{
    [MessageTopic("pedido-pago")]
    public class PedidoPagoMessage : IMessage
    {
        public PedidoPagoMessage(Guid clientId, Guid pedidoId)
        {
            ClientId = clientId;
            PedidoId = pedidoId;
        }

        public Guid PedidoId { get; }
        public Guid ClientId { get; }
    }
}