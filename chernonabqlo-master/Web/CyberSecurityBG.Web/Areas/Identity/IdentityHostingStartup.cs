using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CyberSecurityBG.Web.Areas.Identity.IdentityHostingStartup))]

namespace CyberSecurityBG.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
