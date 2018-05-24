using LightBus.Bus;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace LightBus.Microsoft.DependencyInjection
{
    public static class LightBusExtension
    {
        public static void UseLightBus(this IServiceCollection services)
        {
            services.AddScoped<ILightBus, LightBus>();
            services.AddScoped<IMessageHandlerResolver, MessageHandlerResolver>();

            Assembly.GetCallingAssembly().GetTypes()
                .Where(t => t.GetInterface(typeof(IMessageHandler<>).Name) != null)
                .Select(t => new
                {
                    @interface = t.GetInterface(typeof(IMessageHandler<>).Name),
                    @implementation = t
                })
                .ToList()
                .ForEach(register => services.AddScoped(register.@interface, register.implementation));
        }
    }
}
