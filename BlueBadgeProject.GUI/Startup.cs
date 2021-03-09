using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute("GUIConfig",typeof(BlueBadgeProject.GUI.Startup))]
namespace BlueBadgeProject.GUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
