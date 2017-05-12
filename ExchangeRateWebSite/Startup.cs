using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExchangeRateWebSite.Startup))]
namespace ExchangeRateWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
