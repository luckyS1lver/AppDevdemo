using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GCD0704.AppDev.Startup))]
namespace GCD0704.AppDev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
