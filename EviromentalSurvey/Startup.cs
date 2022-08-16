using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EviromentalSurvey.Startup))]
namespace EviromentalSurvey
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
