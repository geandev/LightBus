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
            .Where(t => t.GetInterface(typeof(IMessageHandler<>).Name) != null)
            .Select(t => new
            {
                abstraction = t.GetInterface(typeof(IMessageHandler<>).Name),
                implementation = t
            })
            .ToList()
            .ForEach(handler => resolver?.Invoke(handler.abstraction, handler.implementation));
        }
    }
}
