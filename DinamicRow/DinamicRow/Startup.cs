using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DinamicRow.Startup))]
namespace DinamicRow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
