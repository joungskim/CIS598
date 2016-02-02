using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CIS598PROJECT.Startup))]
namespace CIS598PROJECT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
