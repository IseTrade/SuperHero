using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Superhero.Startup))]
namespace Superhero
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
