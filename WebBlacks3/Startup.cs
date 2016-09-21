using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebBlacks2.Startup))]
namespace WebBlacks2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
