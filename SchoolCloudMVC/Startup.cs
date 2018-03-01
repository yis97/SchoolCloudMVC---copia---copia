using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolCloudMVC.Startup))]
namespace SchoolCloudMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
