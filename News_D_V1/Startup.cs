using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(News_D_V1.Startup))]
namespace News_D_V1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
