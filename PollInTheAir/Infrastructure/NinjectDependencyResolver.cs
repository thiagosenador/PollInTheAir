using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using PollInTheAir.Domain.Abstract;
using PollInTheAir.Domain.Concrete;

namespace PollInTheAir.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;

            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IPollRepository>().To<PollRepository>();
            kernel.Bind<IQuestionRepository>().To<QuestionRepository>();
        }
    }
}