using System;

namespace Autokool.Tests
{
    public class ServiceProviderMock : IServiceProvider
    {
        private readonly object[] repositories;
        public ServiceProviderMock(params object[] repos) => repositories = repos;
        public object GetService(Type serviceType)
        {
            foreach (var repository in repositories)
            {
                if (repository.GetType().GetInterface(serviceType.Name) is not null)
                    return repository;
            }
            return null;
        }
    }
}
