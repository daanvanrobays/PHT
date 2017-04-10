using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PHT.Startup))]
namespace PHT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
