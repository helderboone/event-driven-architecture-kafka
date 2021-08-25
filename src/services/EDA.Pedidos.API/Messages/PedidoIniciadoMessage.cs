using EDA.Core;
using System;

namespace EDA.Pedidos.API.Messages
{
    [MessageTopic("pedido-iniciado")]
    public class PedidoIniciadoMessage : IMessage
    {
        public PedidoIniciadoMessage(Guid clientId, Guid pedidoId)
        {
            ClientId = clientId;
            PedidoId = pedidoId;
        }

        public Guid PedidoId { get; }
        public Guid ClientId { get; }
    }
}