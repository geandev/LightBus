using System.Threading.Tasks;
using AspNetCore.Sample.Messages;
using LightBus;

namespace AspNetCore.Sample.Handlers
{
    public class SampleMessageResponseHandler : IMessageHandler<SampleMessageResponse, string>
    {
        public Task<string> HandleAsync(SampleMessageResponse message)
        {
            return Task.FromResult($"Hello {message.Value}");
        }
    }
}
