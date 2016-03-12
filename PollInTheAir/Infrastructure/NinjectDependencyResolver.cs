namespace PollInTheAir.Web.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Domain.Repository;
    using Domain.Repository.Impl;
    using Domain.Service;
    using Domain.Service.Impl;
    using Ninject;

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
            this.kernel.Bind<IPollService>().To<PollService>();
            this.kernel.Bind<INoteService>().To<NoteService>();
        }
    }
}