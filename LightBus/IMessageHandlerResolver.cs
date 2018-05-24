using System.Collections.Generic;

namespace LightBus
{
    public interface IMessageHandlerResolver
    {
        IEnumerable<IMessageHandler<TMessage>> GetMessageHandlers<TMessage>() where TMessage : IMessage;
    }
}
