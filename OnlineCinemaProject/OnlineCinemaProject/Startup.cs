using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineCinemaProject.Startup))]
namespace OnlineCinemaProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
