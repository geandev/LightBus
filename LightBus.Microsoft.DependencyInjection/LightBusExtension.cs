using LightBus.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace LightBus.Microsoft.DependencyInjection
{
    public static class LightBusExtension
    {
        public static void AddLightBus(this IServiceCollection services)
        {
            services.AddScoped<ILightBus, LightBus>();
            services.AddScoped<IMessageHandlerResolver, MessageHandlerResolver>();
            LightBusAssemblies.Resolve(
                (abstraction, implementation) => services.AddScoped(abstraction, implementation));
        }
    }
}
