using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SyllabusGenerator.Startup))]
namespace SyllabusGenerator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
