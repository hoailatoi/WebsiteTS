using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebsiteTS.Startup))]
namespace WebsiteTS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
