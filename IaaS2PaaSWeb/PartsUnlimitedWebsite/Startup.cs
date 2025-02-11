using PartsUnlimited;
using System.Web.Configuration;
using Microsoft.AspNetCore.Owin;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

//comment
namespace PartsUnlimited
{
	// bellevue comment!!
	// second commit
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //TODO Application Insights - Uncomment
            //TelemetryConfiguration.Active.InstrumentationKey = WebConfigurationManager.AppSettings["Keys:ApplicationInsights:InstrumentationKey"];

        }
    }
}