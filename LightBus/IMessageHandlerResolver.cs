using System;
using System.Collections.Generic;

namespace LightBus
{
    public interface IMessageHandlerResolver
    {
        IEnumerable<IMessageHandler<TMessage>> GetMessageHandlers<TMessage>()
            where TMessage : IMessage;
        IMessageHandler<TMessage, TResponse> GetMessageHandler<TMessage, TResponse>()
            where TMessage : IMessage<TResponse>, new();
    }
}
