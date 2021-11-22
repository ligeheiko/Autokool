using Autokool.Aids;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Autokool.Domain.Common
{
    public static class GetRepo
    {
        internal static IServiceProvider services;
        public static void SetServiceProvider(IServiceProvider provider) => services = provider;

        public static T Instance<T>() => instance<T>(services);

        public static object Instance(Type t) => instance(services, t);

        internal static T instance<T>(IServiceProvider h)
            => Safe.Run(() => {
                if (h is null) return default;
                var i = h.GetRequiredService<T>();
                return i;
            }, null);

        internal static object instance(IServiceProvider h, Type t)
        {
            return Safe.Run(() =>
            {
                var i = h?.GetRequiredService(t);
                return i;
            }, null);
        }
    }
}

