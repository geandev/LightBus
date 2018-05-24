using LightBus;

namespace AspNetCore.Sample.Messages
{
    public class SampleMessage : IMessage
    {
        public string Value { get; set; }
    }
}
