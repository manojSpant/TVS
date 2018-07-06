using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimeValueProjects.Startup))]
namespace TimeValueProjects
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
