using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomHttpModule.Startup))]
namespace CustomHttpModule
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
