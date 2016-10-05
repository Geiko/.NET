////using LPipe.Contracts;
////using LPipe.Services;
////using Ninject;
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Web;
////using System.Web.Mvc;

////namespace LPipe.UI.Infrastructure
////{
////    public class NinjectDependencyResolver : IDependencyResolver
////    {
////        private IKernel kernel;
////        public NinjectDependencyResolver(IKernel kernelParam)
////        {
////            kernel = kernelParam;
////            AddBindings();
////        }

////        public object GetService(Type serviceType)
////        {
////            return kernel.TryGet(serviceType);
////        }

////        public IEnumerable<object> GetServices(Type serviceType)
////        {
////            return kernel.GetAll(serviceType);
////        }

////        private void AddBindings()
////        {
////            kernel.Bind<IMaterialService>().To<MaterialService>();
            
////        }
////    }
////}

//namespace LPipe.UI.Infrastructure
//{
//    using System;
//    using Ninject.Activation;
//    using Ninject.Infrastructure;
//    using Ninject.Modules;

//    /// <summary>
//    /// Defines bindings for UI layer
//    /// </summary>
//    public class NinjectUIModule : NinjectModule
//    {
//        private readonly Func<IContext, object> _scopeCallback;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="NinjectUIModule"/> class.
//        /// </summary>
//        /// <param name="scopeCallback"> The scope callback. </param>
//        public NinjectUIModule(Func<IContext, object> scopeCallback)
//        {
//            this._scopeCallback = scopeCallback;
//        }

//        /// <summary>
//        /// Loads bindings
//        /// </summary>
//        public override void Load()
//        {
//        //    IHaveBindingConfiguration configuration = Bind<ICurrentUserService>().To<CurrentUserService>();
//        //    configuration.BindingConfiguration.ScopeCallback = _scopeCallback;
//        }
//    }
//}