using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(xzmcwjzs.ntu.MVC.UI.Startup))]
namespace xzmcwjzs.ntu.MVC.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
