using System.Diagnostics;
using System.Threading.Tasks;
using AspNetCore.Sample.Messages;
using LightBus;

namespace AspNetCore.Sample.Handlers
{
    public class SampleMessageHandler : IHandler<SampleMessage>
    {
        public Task HandleAsync(SampleMessage message)
        {
            Debug.WriteLine(message.Value);
            return Task.CompletedTask;
        }
    }
}
