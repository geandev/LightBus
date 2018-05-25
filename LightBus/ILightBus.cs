using System;
using System.Threading.Tasks;

namespace LightBus.Bus
{
    public interface ILightBus
    {
        Task PushAsync<TMessage>(TMessage message)
            where TMessage : IMessage;

        Task<TResponse> SendAsync<TMessage, TResponse>(Action<TMessage> messageHandler = null)
            where TMessage : IMessage<TResponse>, new();
    }
}
