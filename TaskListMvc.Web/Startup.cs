using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskListMvc.Web.Startup))]
namespace TaskListMvc.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
