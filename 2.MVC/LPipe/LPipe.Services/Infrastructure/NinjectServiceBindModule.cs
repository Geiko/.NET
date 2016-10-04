//using LPipe.Contracts;
//using LPipe.Services;
//using Ninject;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace LPipe.Services.Infrastructure
//{
//    public class NinjectServiceBindModule : IDependencyResolver
//    {
//        private IKernel kernel;
//        public NinjectServiceBindModule(IKernel kernelParam)
//        {
//            kernel = kernelParam;
//            AddBindings();
//        }

//        public object GetService(Type serviceType)
//        {
//            return kernel.TryGet(serviceType);
//        }

//        public IEnumerable<object> GetServices(Type serviceType)
//        {
//            return kernel.GetAll(serviceType);
//        }

//        private void AddBindings()
//        {
//            kernel.Bind<IMaterialService>().To<MaterialService>();
//        }
//    }
//}

namespace Academy.BLL.Infrastructure
{
    using LPipe.Data.Contracts;
    using Ninject.Modules;

    public class ServiceModule : NinjectModule
    {
        private string _connectionString;

        public ServiceModule(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<LPipeUnitOfWork>().WithConstructorArgument(this._connectionString);
        }
    }
}