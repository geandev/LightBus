using LightBus;

namespace AspNetCore.Sample.Messages
{
    public class SampleMessageResponse : IMessage<string>
    {
        public string Value { get; set; }
    }
}
