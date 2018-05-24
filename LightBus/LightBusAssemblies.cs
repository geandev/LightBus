using System;
using System.Linq;

namespace LightBus
{
    public static class LightBusAssemblies
    {
        public static void Resolve(Action<Type, Type> resolver)
        {
            AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.GetInterface(typeof(IMessageHandler<>).Name) != null)
                .Select(t => new
                {
                    abstraction = t.GetInterface(typeof(IMessageHandler<>).Name),
                    implementation = t
                })
                .ToList().ForEach(handler => resolver(handler.abstraction, handler.implementation));
        }
    }
}
