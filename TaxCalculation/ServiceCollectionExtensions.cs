using TaxCalculation.Repository;
using TaxCalculation.Service;

namespace TaxCalculation
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterAllServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceHolder, ServiceHolder>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();



        }
    }
}
