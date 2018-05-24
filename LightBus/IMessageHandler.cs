using System.Threading.Tasks;

namespace LightBus
{
    public interface IMessageHandler<TMessage>
        where TMessage : IMessage
    {
        Task HandleAsync(TMessage message);
    }
}
