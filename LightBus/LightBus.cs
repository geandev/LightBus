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
        public Task SendAsync<TMessage>(TMessage message)
            where TMessage : IMessage

        {
            return Task.WhenAll(_messageHandlerResolver.GetMessageHandlers<TMessage>().Select(m => m.HandleAsync(message)));
        }
    }
}
