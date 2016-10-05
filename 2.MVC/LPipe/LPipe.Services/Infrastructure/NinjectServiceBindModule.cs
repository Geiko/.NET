namespace LPipe.Services.Infrastructure
{
    using System;
    using Ninject.Activation;
    using Ninject.Infrastructure;
    using Ninject.Modules;
    using LPipe.Contracts;
    using LPipe.Crosscutting.Ninject;
    using LPipe.Services;
    public class NinjectServiceBindModule : NinjectModule
    {
        private readonly Func<IContext, object> _scopeCallback;


        public NinjectServiceBindModule(Func<IContext, object> scopeCallback)
        {
            _scopeCallback = scopeCallback;
        }


        public override void Load()
        {
            var configs = new IHaveBindingConfiguration[]
                              {
                                  Bind<IMaterialService>().To<MaterialService>()
                              };
            configs.InScope(_scopeCallback);
        }
    }
}
