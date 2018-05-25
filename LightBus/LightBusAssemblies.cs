using System;
using System.Linq;
using System.Reflection;

namespace LightBus
{
    public static class LightBusAssemblies
    {
        public static void Resolve(Action<Type, Type> resolver)
        {
            var entryPointAssembly = Assembly.GetEntryAssembly();
            var referenceAssemblies = entryPointAssembly
                .GetReferencedAssemblies()
                .Select(Assembly.Load);

            entryPointAssembly
            .GetTypes()
            .Union(referenceAssemblies.SelectMany(a => a.GetTypes()))
            .Where(t => isMessageHandler(t) || isMessageHandlerWithResponse(t))
            .Select(t => new
            {
                abstraction = isMessageHandler(t) ? t.GetInterface(typeof(IMessageHandler<>).Name) : t.GetInterface(typeof(IMessageHandler<,>).Name),
                implementation = t
            })
            .ToList()
            .ForEach(handler => resolver?.Invoke(handler.abstraction, handler.implementation));

            bool isMessageHandler(Type type) => type.GetInterface(typeof(IMessageHandler<>).Name) != null;
            bool isMessageHandlerWithResponse(Type type) => type.GetInterface(typeof(IMessageHandler<,>).Name) != null;
        }
    }
}
