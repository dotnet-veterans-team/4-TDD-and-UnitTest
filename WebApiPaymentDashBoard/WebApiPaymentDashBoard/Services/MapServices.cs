using System.Diagnostics.CodeAnalysis;
using WebApiBankDashBoard.Interfaces;

namespace WebApiBankDashBoard.Services
{
    [ExcludeFromCodeCoverage]
    public static class MapServices
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMathService, MathService>();
            services.AddScoped<IAuthentication, Authentication>();
            services.AddScoped<ITransactionService, ITransactionService>();
            services.AddScoped<IAccountManagementService, AccountManagementService>();

            return services;
        }
    }
}
