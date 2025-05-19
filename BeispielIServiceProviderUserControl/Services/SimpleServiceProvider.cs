using System;
using System.Collections.Generic;

namespace BeispielIServiceProviderUserControl.Services
{
    public class SimpleServiceProvider : IServiceProvider
    {
        private readonly Dictionary<Type, Func<object>> _registrations = new Dictionary<Type, Func<object>>();

        public void Register<TService>(Func<TService> factory)
        {
            _registrations[typeof(TService)] = () => factory();
        }

        public object GetService(Type serviceType)
        {
            return _registrations.TryGetValue(serviceType, out var creator)
                ? creator()
                : throw new InvalidOperationException($"Service not registered: {serviceType}");
        }

        public T Get<T>() => (T)GetService(typeof(T));
    }
}
