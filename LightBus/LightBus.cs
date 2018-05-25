using System;
using System.Linq;
using System.Threading.Tasks;
using LightBus.Bus;

namespace LightBus
{
    public class LightBus : ILightBus
    {
        private readonly IMessageHandlerResolver _messageHandlerResolver;

        public LightBus(IMessageHandlerResolver messageHandlerResolver)
        {
            _messageHandlerResolver = messageHandlerResolver;
        }

        public Task PushAsync<TMessage>(TMessage message) where TMessage : IMessage
        {
            return Task.WhenAll(_messageHandlerResolver.GetMessageHandlers<TMessage>().Select(m => m.HandleAsync(message)));
        }

        public Task<TResponse> SendAsync<TMessage, TResponse>(Action<TMessage> messageHandler = null) where TMessage : IMessage<TResponse>, new()
        {
            var message = new TMessage();
            messageHandler?.Invoke(message);
            return _messageHandlerResolver.GetMessageHandler<TMessage, TResponse>().HandleAsync(message);
        }
    }
}
