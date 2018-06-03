using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmprestimosJogos.Startup))]
namespace EmprestimosJogos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
