using System;
using CommandMechanism.Base.Interfaces;

namespace CommandMechanism.Base
{
    public class ComponentResolver : IComponentResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public ComponentResolver(IServiceProvider serviceCollection)
        {
            _serviceProvider = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));
        }

        public T Resolve<T>() where T : class
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }
    }
}