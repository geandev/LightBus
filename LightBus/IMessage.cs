namespace LightBus
{
    public interface IMessage
    {
    }

    public interface IMessage<out TResponse>
    {
    }
}
