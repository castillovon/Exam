using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamCounter.Startup))]
namespace ExamCounter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
