using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mohawk.Executive.Web.Startup))]
namespace Mohawk.Executive.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
