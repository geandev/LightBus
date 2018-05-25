using System.Threading.Tasks;

namespace LightBus
{
    public interface IMessageHandler<in TMessage>
        where TMessage : IMessage
    {
        Task HandleAsync(TMessage message);
    }

    public interface IMessageHandler<in TMessage, TResponse>
        where TMessage : IMessage<TResponse>, new()
    {
        Task<TResponse> HandleAsync(TMessage message);
    }
}
