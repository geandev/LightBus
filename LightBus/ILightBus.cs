using System.Threading.Tasks;

namespace LightBus.Bus
{
    public interface ILightBus
    {
        Task SendAsync<TMessage>(TMessage message)
        where TMessage : IMessage;
    }
}
