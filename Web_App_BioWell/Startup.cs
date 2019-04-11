using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_App_BioWell.Startup))]
namespace Web_App_BioWell
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
