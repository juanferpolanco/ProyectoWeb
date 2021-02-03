using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FertiWeb.Startup))]
namespace FertiWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
