using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecruitingWeb.Startup))]
namespace RecruitingWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
