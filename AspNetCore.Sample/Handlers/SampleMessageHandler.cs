using System.Diagnostics;
using System.Threading.Tasks;
using AspNetCore.Sample.Messages;
using LightBus;

namespace AspNetCore.Sample.Handlers
{
    public class SampleMessageHandler : IMessageHandler<SampleMessage>
    {
        public Task HandleAsync(SampleMessage message)
        {
            Debug.WriteLine(nameof(SampleMessage), "Called");
            return Task.CompletedTask;
        }
    }
}
