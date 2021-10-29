using System;

namespace Autokool.Tests
{
    public class ServiceProviderMock : IServiceProvider
    {
        private readonly object repository;
        public ServiceProviderMock(object repo) => repository = repo;
        public object GetService(Type serviceType) => repository;
    }
}
