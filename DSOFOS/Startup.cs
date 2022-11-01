using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DSOFOS.Startup))]
namespace DSOFOS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
