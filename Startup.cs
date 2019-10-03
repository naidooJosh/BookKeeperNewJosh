using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookKeeperNewJosh.Startup))]
namespace BookKeeperNewJosh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
