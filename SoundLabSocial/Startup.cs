using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoundLabSocial.Startup))]
namespace SoundLabSocial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
