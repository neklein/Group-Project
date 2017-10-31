using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeaMonsterBlog.UI.Startup))]
namespace SeaMonsterBlog.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
