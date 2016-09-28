using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PipeStore.Startup))]
namespace PipeStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
