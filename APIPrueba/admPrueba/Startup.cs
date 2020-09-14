using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(admPrueba.Startup))]
namespace admPrueba
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
