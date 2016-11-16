using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebQLVanBan.Startup))]
namespace WebQLVanBan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
