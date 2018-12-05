using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Examen1NETWEB.Startup))]
namespace Examen1NETWEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
