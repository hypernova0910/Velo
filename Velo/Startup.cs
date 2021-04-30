using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Velo.Startup))]
namespace Velo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //thêm dong code này nhé các bạn
            app.MapSignalR();
        }
    }
}