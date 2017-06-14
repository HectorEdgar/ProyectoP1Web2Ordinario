using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoP1Web2.Startup))]
namespace ProyectoP1Web2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
