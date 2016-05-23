using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PonyRidesWebSite.Startup))]
namespace PonyRidesWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
