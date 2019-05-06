using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarMeetFinderMVC.Startup))]
namespace CarMeetFinderMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
