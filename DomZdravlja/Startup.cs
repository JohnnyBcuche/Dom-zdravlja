using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DomZdravlja.Startup))]
namespace DomZdravlja
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
