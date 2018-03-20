using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Final.Web.Startup))]
namespace Final.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
