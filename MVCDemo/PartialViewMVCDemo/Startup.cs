using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PartialViewMVCDemo.Startup))]
namespace PartialViewMVCDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
