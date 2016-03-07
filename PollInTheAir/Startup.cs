using Microsoft.Owin;
using Owin;
using PollInTheAir.Web;

[assembly: OwinStartup(typeof(Startup))]

namespace PollInTheAir.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}