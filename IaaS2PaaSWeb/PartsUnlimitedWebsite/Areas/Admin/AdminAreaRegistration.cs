using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace PartsUnlimited.Areas.Admin
{
    public static class AdminAreaRegistration
    {
        public static void RegisterArea(IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "admin_default",
                    areaName: AdminConstants.Area,
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}",
                    defaults: new { area = AdminConstants.Area }
                );
            });
        }
    }
}