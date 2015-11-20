using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CFT.UI.Startup))]
namespace CFT.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
