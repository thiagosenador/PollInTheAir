namespace PollInTheAir.Web.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Ninject;

    using PollInTheAir.Domain.Repository;
    using PollInTheAir.Domain.Repository.Impl;

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;

            this.AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return this.kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            this.kernel.Bind<ICatalog>().To<Catalog>();
        }
    }
}