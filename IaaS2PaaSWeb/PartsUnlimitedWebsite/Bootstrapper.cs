using Microsoft.Extensions.DependencyInjection;

namespace PartsUnlimited
{
    public static class Bootstrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // Register your services here
            // e.g. services.AddTransient<ITestService, TestService>();

            RegisterTypes(services);
        }

        public static void RegisterTypes(IServiceCollection services)
        {
            // Add your service registrations here
        }
    }
}