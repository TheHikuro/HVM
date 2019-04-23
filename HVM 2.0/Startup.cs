using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HVM_2._0.Startup))]
namespace HVM_2._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
