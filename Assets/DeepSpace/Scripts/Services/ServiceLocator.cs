using System.Collections.Generic;
using System;

namespace DeepSpace
{
    public class ServiceLocator : IDisposable
    {
        private Dictionary<Type, IService> _singletonServices = new();
        private Dictionary<Type, Func<ServiceLocator, IService>> _factoryServices = new();
        
        private List<IService> _services = new();
        
        public void Dispose()
        {
            foreach(var service in _singletonServices.Values)
                service.Dispose();
            
            foreach (var service in _services)
                service.Dispose();
        }
        
        public void RegisterSingletonService<T>(Func<ServiceLocator, T> factoryService) where T : IService
        {
            var service = factoryService(this);
            var typeService = typeof(T);
            
            if (!_singletonServices.ContainsKey(typeService))
            {
                _singletonServices.Add(typeService, service);
            }
        }

        public void RegisterService<T>(Func<ServiceLocator, T> factoryService) where T : class, IService
        {
            var typeService = typeof(T);

            if (!_factoryServices.ContainsKey(typeService))
            {
                _factoryServices.Add(typeService, factoryService);
            }
        }

        public T GetService<T>() where T : IService
        {
            var typeService = typeof(T);
            
            foreach (var singletonService in _singletonServices)
            {
                if (singletonService.Key == typeService)
                {
                    return (T)singletonService.Value;
                }
            }

            foreach (var factoryService in _factoryServices)
            {
                if (factoryService.Key == typeService)
                {
                    var newService = factoryService.Value(this);
                    _services.Add(newService);
                    return (T)newService;
                }
            }
            
            return default;
        }
    }
}