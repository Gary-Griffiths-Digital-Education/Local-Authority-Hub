using LAHub.Domain.Interfaces;
using OrganistionAdmin.WebUI.Services;

namespace OrganistionAdmin.WebUI
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebUIServices(this IServiceCollection services)
        {
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.AddRazorPages();
            return services;
        }
    }
}
