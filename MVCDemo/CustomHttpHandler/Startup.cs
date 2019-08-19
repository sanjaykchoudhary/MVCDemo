using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomHttpHandler.Startup))]
namespace CustomHttpHandler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
