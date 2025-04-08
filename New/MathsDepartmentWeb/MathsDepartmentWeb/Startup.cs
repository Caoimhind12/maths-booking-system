using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MathsDepartmentWeb.Startup))]
namespace MathsDepartmentWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
