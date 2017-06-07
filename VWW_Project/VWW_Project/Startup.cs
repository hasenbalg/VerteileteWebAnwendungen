using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VWW_Project.Startup))]
namespace VWW_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
