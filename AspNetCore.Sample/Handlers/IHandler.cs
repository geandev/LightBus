using LightBus;

namespace AspNetCore.Sample.Handlers
{
    public interface IHandler<TMessage> : IMessageHandler<TMessage>
        where TMessage : IMessage
    {
    }
}
