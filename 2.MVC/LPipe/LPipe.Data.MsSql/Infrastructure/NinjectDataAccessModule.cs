namespace LPipe.Data.MsSql.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using Ninject.Activation;
    using Ninject.Extensions.Conventions;
    using Ninject.Infrastructure;
    using Ninject.Modules;
    using Ninject.Planning.Bindings;
    using LPipe.Crosscutting.Ninject;
    using LPipe.Data.Contracts;
    using LPipe.Data.MsSql.Queries;
    using LPipe.Data.MsSql.Repositories;
    using LPipe.Domain.MaterialsAggregate;
    using LPipe.Data.Queries.Common;

    public class NinjectDataAccessModule : NinjectModule
    {
        private readonly Func<IContext, object> _scopeCallback;

        public NinjectDataAccessModule(Func<IContext, object> scopeCallback)
        {
            this._scopeCallback = scopeCallback;
        }

        /// <summary>
        /// Loads bindings
        /// </summary>
        public override void Load()
        {
            // Bind all queries
            Kernel.Bind(x =>
                    x.FromThisAssembly()
                     .SelectAllClasses()
                     //.InNamespaceOf<TournamentQueries>()
                     .BindAllInterfaces()
                     .Configure(c => c.InTransientScope()));

            var configs = new IHaveBindingConfiguration[]
                              {
                                  //Bind<IQuery<List<Material>, GetAllCriteria>>().To<MaterialQueries>(),
                                  //Bind<IUnitOfWork>().To<LPipeUnitOfWork>(),
                                  //Bind<IMaterialRepository>().To<MaterialRepository>()
                              };

            configs.InScope(_scopeCallback);
        }
    }
}
